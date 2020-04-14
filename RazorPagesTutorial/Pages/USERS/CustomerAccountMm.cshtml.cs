using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace RazorPagesTutorial.Pages.USERS
{
    public class CustomerAccountMmModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public CustomerAccountMmModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        [BindProperty]
        public USER USERS { get; set; }
        public string url,url1,Msg;

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

            USERS = await _context.USERS.FirstOrDefaultAsync(m => m.U_ID == id);

            if (USERS == null)
            {
                return NotFound();
            }
            /*
            if (USERS.U_Role == "Master")
            {
                return RedirectToPage("../USERS/Index");
            }*/
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (USERS.U_Role.Equals("Master"))
            {
                return RedirectToPage("../USERS/Index");
            }*/
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(USERS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERSExists(USERS.U_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Msg = "Save succeed";
            return Page();
        }

        private bool USERSExists(int id)
        {
            return _context.USERS.Any(e => e.U_ID == id);
        }
    }
}
