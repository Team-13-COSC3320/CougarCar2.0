using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using System.Data;
using System.Data.SqlClient;

namespace RazorPagesTutorial.Pages.USERS
{
    public class RegisterModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        public string url;
        public RegisterModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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
            SqlCommand cmd = new SqlCommand("dbo.users_insert_register", sqlConnection);

            cmd.Parameters.Add("@u_id", SqlDbType.Int).Value = USERS.U_ID;
            cmd.Parameters.Add("@u_pass", SqlDbType.Char).Value = USERS.U_Pass;
            cmd.Parameters.Add("@u_fName", SqlDbType.Char).Value = USERS.U_FName;
            cmd.Parameters.Add("@u_lName", SqlDbType.Char).Value = USERS.U_LName;
            cmd.Parameters.Add("@u_address", SqlDbType.Char).Value = USERS.U_Address;
            cmd.Parameters.Add("@u_country", SqlDbType.Char).Value = USERS.U_Country;
            cmd.Parameters.Add("@u_zipcode", SqlDbType.Int).Value = USERS.U_Zipcode;
            cmd.Parameters.Add("@u_phone", SqlDbType.Char).Value = USERS.U_Phone;
            cmd.Parameters.Add("@u_email", SqlDbType.Char).Value = USERS.U_Email;
            cmd.Parameters.Add("@u_msg", SqlDbType.Char).Value = "";
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            List<USER> users = _context.getUserList();

            url = "./RegisterSucceed?id=" + users[users.Count() - 1].U_ID;
            return Redirect(url);
        }
    }
}