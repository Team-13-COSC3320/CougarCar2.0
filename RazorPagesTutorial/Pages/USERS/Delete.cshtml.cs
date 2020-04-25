using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RazorPagesTutorial.Pages.USERS
{
    public class DeleteModel2 : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public DeleteModel2(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        [BindProperty]
        public USER USERS { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            USERS = _context.getUser(id.GetValueOrDefault());

            if (USERS == null)
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
            USERS = _context.getUser(id.GetValueOrDefault());

            SqlConnection sqlConnection = new SqlConnection(_context.connection);
            SqlCommand cmd = new SqlCommand("dbo.users_delete", sqlConnection);

            cmd.Parameters.Add("@u_id", SqlDbType.Int).Value = USERS.U_ID;
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
