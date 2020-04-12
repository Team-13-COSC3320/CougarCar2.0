using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Pages.USERS
{
    public class CreateModel2 : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public CreateModel2(RazorPagesTutorialContext context)
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

            _context.USERS.Add(USERS);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
