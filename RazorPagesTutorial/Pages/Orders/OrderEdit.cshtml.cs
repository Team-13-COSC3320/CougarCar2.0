using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Data;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace RazorPagesTutorial
{
    public class OrderEditModel : PageModel
    {
        [BindProperty]
        public Orders Order { get; set; }

        private readonly RazorPagesTutorialContext _context;

        public OrderEditModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

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

            Order = _context.getOrder(id.GetValueOrDefault());
            
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            
            SqlConnection sqlConnection = new SqlConnection(_context.connection);

            string query = "Update dbo.ORDERS " +
                            "Set " +
                            "O_Status = @O_Status " +
                            "Where O_ID = @O_ID"; 
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.Add("@O_Status", SqlDbType.Char).Value = Order.O_Status;
            cmd.Parameters.Add("@O_ID", SqlDbType.Int).Value = Order.O_ID;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
           
            return RedirectToPage("./OrderTable");
        }
    }
}