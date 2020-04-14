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

            USERS = await _context.USERS.FirstOrDefaultAsync(m => m.U_ID == id);

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

            USERS = await _context.USERS.FindAsync(id);

            if (USERS != null)
            {
                _context.USERS.Remove(USERS);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
