using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Pages.USERS
{
    public class EditModel2 : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public EditModel2(RazorPagesTutorialContext context)
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
            if(USERS.U_Role == "Master")
            {
                return RedirectToPage("/USERS/Index");
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (USERS.U_Role.Equals("Master"))
            {
                return RedirectToPage("/USERS/Index");
            }
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

            return RedirectToPage("./Index");
        }

        private bool USERSExists(int id)
        {
            return _context.USERS.Any(e => e.U_ID == id);
        }
    }
}
