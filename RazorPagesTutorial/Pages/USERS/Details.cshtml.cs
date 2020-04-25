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
    public class DetailsModel2 : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public DetailsModel2()
        {
            _context = new RazorPagesTutorialContext();
        }

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
    }
}
