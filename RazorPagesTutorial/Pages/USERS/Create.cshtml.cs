using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RazorPagesTutorial.Pages.USERS
{
    public class CreateModel2 : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public CreateModel2()
        {
            _context = new RazorPagesTutorialContext();
        }

        public IActionResult OnGet()
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
            return Page();
        }

        [BindProperty]
        public USER USERS { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SqlConnection sqlConnection = new SqlConnection(_context.connection);
            SqlCommand cmd = new SqlCommand("dbo.users_insert_master", sqlConnection);

            cmd.Parameters.Add("@u_id", SqlDbType.Int).Value = USERS.U_ID;
            cmd.Parameters.Add("@u_pass", SqlDbType.Char).Value = USERS.U_Pass;
            cmd.Parameters.Add("@u_fName", SqlDbType.Char).Value = USERS.U_FName;
            cmd.Parameters.Add("@u_lName", SqlDbType.Char).Value = USERS.U_LName;
            cmd.Parameters.Add("@u_address", SqlDbType.Char).Value = USERS.U_Address;
            cmd.Parameters.Add("@u_country", SqlDbType.Char).Value = USERS.U_Country;
            cmd.Parameters.Add("@u_zipcode", SqlDbType.Int).Value = USERS.U_Zipcode;
            cmd.Parameters.Add("@u_phone", SqlDbType.Char).Value = USERS.U_Phone;
            cmd.Parameters.Add("@u_email", SqlDbType.Char).Value = USERS.U_Email;
            cmd.Parameters.Add("@u_role", SqlDbType.Char).Value = USERS.U_Role;
            cmd.Parameters.Add("@u_msg", SqlDbType.Char).Value = "";
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return RedirectToPage("./Index");
        }
    }
}
