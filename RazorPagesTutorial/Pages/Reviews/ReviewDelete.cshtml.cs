using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace RazorPagesTutorial
{
    public class ReviewDeleteModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public ReviewDeleteModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public Review Review{ get; set; }

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
            Review = _context.getReview(id.GetValueOrDefault());
            Product = _context.getProduct(Review.ID);
            if (Review == null)
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

            SqlConnection sqlConnection = new SqlConnection(_context.connection);
            SqlCommand cmd = new SqlCommand("dbo.delete_Review", sqlConnection);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id.GetValueOrDefault();
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            //If admin do this
            if ((String)ViewData["UserRole"] == "Admin")
            {
                return RedirectToPage("./ReviewTable");
            }
            else //If not admin
            {
                return RedirectToPage("/Products/ProductList");
            }
        }
    }
}