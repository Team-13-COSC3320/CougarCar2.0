using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace RazorPagesTutorial.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public DetailsModel()
        {
            _context = new RazorPagesTutorialContext();
        }


        public List<Product> Products { get; set; }

        public Product Product { get; set; }

        public List<Review> validReviews { get; private set; }

        public int SelectedId { get; set; }

        public SelectList productSelectList { get; set; }

        public ActionResult Submit()
        {
            return new RedirectToPageResult("/Product/Details?ID=" + SelectedId);
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {

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
            Product = _context.getProduct(id.GetValueOrDefault());
            Products = _context.getProductList();
            productSelectList = new SelectList(Products, "ID", "P_Name");
            SelectedId = 1;

            validReviews = _context.GetReviewsOnProduct(id.GetValueOrDefault());

            return Page();
        }
    }
}
