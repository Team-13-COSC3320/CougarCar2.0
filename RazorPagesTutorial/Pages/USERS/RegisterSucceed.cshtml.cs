using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Pages.USERS
{
    public class RegisterSucceedModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        
        public string url,Msg;
        public USER USERS { get; set; }
        public RegisterSucceedModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            USERS = await _context.USERS.FirstOrDefaultAsync(m => m.U_ID == id);
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