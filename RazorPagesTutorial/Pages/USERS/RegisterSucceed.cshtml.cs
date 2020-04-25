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

namespace RazorPagesTutorial.Pages.USERS
{
    public class RegisterSucceedModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        
        public string url,Msg;
        public USER USERS { get; set; }
        public RegisterSucceedModel()
        {
            _context = new RazorPagesTutorialContext();
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

            USERS = _context.getUser(id.GetValueOrDefault());
            Msg = USERS.U_ID.ToString();
            //url = "../Products/Products?id=" + USERS.U_ID;
            if (USERS == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}