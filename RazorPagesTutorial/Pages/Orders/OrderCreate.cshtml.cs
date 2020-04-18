using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace RazorPagesTutorial
{
    public class OrderCreateModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;

        public OrderCreateModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Orders Order {get; set; }

        
        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
            Product = await _context.Product.FirstOrDefaultAsync(m => m.P_ID == id);
            Order = new Orders();
            Order.O_Status = "Processing";
            Order.O_Date = DateTime.Now;
            Order.O_UID = int.Parse(ViewData["UserId"].ToString());
            Order.O_PIDS = Product.P_ID;
            Product.P_Amount -= 1;



            //_context.Orders.Add(Order);
            //await _context.SaveChangesAsync();

            if (Product == null)
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
            Product = await _context.Product.FirstOrDefaultAsync(m => m.P_ID == id);
            Order = new Orders();

            Order.O_Status = "Processing";
            Order.O_Date = DateTime.Now;
            Order.O_UID = Int32.Parse(ViewData["Userid"].ToString());
            Order.O_PIDS = Product.P_ID;
            Product.P_Amount -= 1;



            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();


            return RedirectToPage("/Products/ProductList");
        }
    }
}