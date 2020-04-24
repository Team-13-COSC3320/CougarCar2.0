using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace RazorPagesTutorial.Pages.Orders
{
    public class OrderDeleteModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        public OrderDeleteModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }


        [BindProperty]
        public RazorPagesTutorial.Models.Orders Order { get; set; }


        [BindProperty]
        public Product P { get; set; }

        public string role { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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
                role = ViewData["UserRole"].ToString();
            }
            Order = _context.getOrder(id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Order = _context.getOrder(id);

            P = _context.getProduct(Order.O_PIDS.GetValueOrDefault());

            if (Order != null)
            {

                SqlConnection sqlConnection = new SqlConnection(_context.connection);

                SqlCommand cmd = new SqlCommand("dbo.delete_Order", sqlConnection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@p_id", SqlDbType.Int).Value = P.P_ID;
                cmd.Parameters.Add("@p_amount", SqlDbType.Int).Value = P.P_Amount + 1;
                cmd.CommandType = CommandType.StoredProcedure;
                

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            if (HttpContext.Session.Get("Role") != null)
            {
                byte[] str = HttpContext.Session.Get("Role");
                string Role = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["UserRole"] = Role;
                role = ViewData["UserRole"].ToString();
            }
            if (role == "Admin" || role == "Master")
            {
                return RedirectToPage("./OrderTable");
            }
            else
            {
                return RedirectToPage("./OrderCustomerTable");
            }
            
        }
    }
}