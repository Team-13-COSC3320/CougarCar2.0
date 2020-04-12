using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesTutorial
{
    public class ReviewTableModel : PageModel
    {

        RazorPagesTutorial.Data.RazorPagesTutorialContext _context { get; set; }
        public IList<Review> Review { get; private set; }

        public ReviewTableModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Review = await _context.Review.ToListAsync();
        }
    }
}