using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Data;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace RazorPagesTutorial
{
    public class ProductListModel : PageModel
    {

        private readonly RazorPagesTutorialContext _context;

        public ProductListModel()
        {
            _context = new RazorPagesTutorialContext();
        }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync()
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
            Product = _context.getProductList();
        }
    }
}