using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace RazorPagesTutorial.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        private IWebHostEnvironment _environment;
        public DeleteModel( IWebHostEnvironment environment)
        {
            _context = new RazorPagesTutorialContext();
            _environment = environment;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

            List<Product> list = _context.Product.ToList();
            var test = list.Last();
            string removing = _environment.WebRootPath.ToString() + "/Images/" + test.P_Image;
            if (System.IO.File.Exists(removing))
            {
                System.IO.File.Delete(removing);
            }
            Models.Product p = _context.getProduct(id.GetValueOrDefault());
            List<RazorPagesTutorial.Models.Orders> order = _context.getOrderList();
            foreach (Models.Orders O in order)
            {
                if (id.GetValueOrDefault() == O.O_PIDS)
                {
                    if (O.O_Status.Contains("Processing"))
                    {
                        SqlConnection sql = new SqlConnection(_context.connection);

                        SqlCommand cm = new SqlCommand("dbo.delete_Order", sql);
                        cm.Parameters.Add("@id", SqlDbType.Int).Value = O.O_ID;
                        cm.Parameters.Add("@p_id", SqlDbType.Int).Value = p.P_ID;
                        cm.Parameters.Add("@p_amount", SqlDbType.Int).Value = p.P_Amount + 1;
                        cm.CommandType = CommandType.StoredProcedure;


                        sql.Open();
                        cm.ExecuteNonQuery();
                        sql.Close();
                    }
                }
            }

            SqlConnection sqlConnection = new SqlConnection(_context.connection);
            SqlCommand cmd = new SqlCommand("dbo.delete_Product", sqlConnection);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id.GetValueOrDefault();
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return RedirectToPage("./Index");
        }
    }
}
