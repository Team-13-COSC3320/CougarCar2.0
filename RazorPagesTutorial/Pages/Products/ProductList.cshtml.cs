using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial
{
    public class ProductListModel : PageModel
    {

        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;

        public ProductListModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}