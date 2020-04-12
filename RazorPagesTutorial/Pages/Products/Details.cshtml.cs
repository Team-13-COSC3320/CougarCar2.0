using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;

        public DetailsModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }


        public List<Product> Products { get; set; }

        public Product Product { get; set; }

        public List<Review> validReviews { get; private set; }

        public int SelectedId { get; set; }

        public SelectList productSelectList { get; set; }

        //public void OnGet(int? Id) {
        //    RedirectToPage("/Product/Details?ID=" + Id);        
        //}

        

        public ActionResult Submit()
        {
            return new RedirectToPageResult("/Product/Details?ID=" + SelectedId);
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            

            Product = await _context.Product.AsNoTracking().FirstOrDefaultAsync(m => m.P_ID == id);
            Products = await _context.Product.ToListAsync();
            productSelectList = new SelectList(Products, "ID", "P_Name");
            SelectedId = 1;

            validReviews = _context.GetReviewsOnProduct(id);

            return Page();
        }
    }
}
