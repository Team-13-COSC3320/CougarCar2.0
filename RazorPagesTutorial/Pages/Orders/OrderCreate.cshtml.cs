﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Data;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RazorPagesTutorial
{
    public class OrderCreateModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public OrderCreateModel()
        {
            _context = new RazorPagesTutorialContext();
        }

        [BindProperty]
        public Orders Order {get; set; }

        
        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.Get("Id") != null)
            {
                byte[] str = HttpContext.Session.Get("Id");
                string ID = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["Userid"] = ID;
            }
            if (HttpContext.Session.Get("Role") != null)
            {
                byte[] str = HttpContext.Session.Get("Role");
                string Role = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["UserRole"] = Role;
            }
            Product = _context.getProduct(id.GetValueOrDefault());
            Order = new Orders();
            Order.O_Status = "Processing";
            Order.O_Date = DateTime.Now;
            Order.O_UID = int.Parse(ViewData["UserId"].ToString());
            Order.O_PIDS = Product.P_ID;

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (HttpContext.Session.Get("Id") != null)
            {
                byte[] str = HttpContext.Session.Get("Id");
                string ID = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["Userid"] = ID;
            }
            if (HttpContext.Session.Get("Role") != null)
            {
                byte[] str = HttpContext.Session.Get("Role");
                string Role = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["UserRole"] = Role;
            }
            Product = _context.getProduct(id.GetValueOrDefault());
            Order = new Orders();

            Order.O_Status = "Processing";
            Order.O_Date = DateTime.Now;
            Order.O_UID = Int32.Parse(ViewData["Userid"].ToString());
            Order.O_PIDS = Product.P_ID;

            string connection = "Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection sqlConnection = new SqlConnection(connection);

            string query = "Insert into Orders" +

                        " (O_Date, O_UID, O_PIDS, O_Amount, O_Status)  " +

                        "Values (@myDate, @uid, @pid, 1, 'Processing')";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.Add("@myDate", SqlDbType.Char).Value = Order.O_Date;

            cmd.Parameters.Add("@uid", SqlDbType.Char).Value = Order.O_UID;

            cmd.Parameters.Add("@pid", SqlDbType.Int).Value = Order.O_PIDS;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
   
            return RedirectToPage("/Orders/OrderCustomerTable");
        }
    }
}