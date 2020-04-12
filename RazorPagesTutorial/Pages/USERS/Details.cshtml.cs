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
    public class DetailsModel2 : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public DetailsModel2(RazorPagesTutorialContext context)
        {
            _context = context;
        }

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
    }
}
