using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text;


namespace RazorPagesTutorial.Pages.Orders
{
    public class OrderDeleteModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        public OrderDeleteModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }


        [BindProperty]
        public RazorPagesTutorial.Models.Orders Order { get; set; }


        [BindProperty]
        public Product P { get; set; }

        public string role { get; set; }

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
                role = ViewData["UserRole"].ToString();
            }
            Order = await _context.Orders.FirstOrDefaultAsync(m => m.O_ID == id);

            if (Order == null)
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

            List<RazorPagesTutorial.Models.Orders> list = _context.Orders.ToList();
            var test = list.Last();
            //string removing = _environment.WebRootPath.ToString() + "/Images/" + test.P_Image;
            //if (System.IO.File.Exists(removing))
            //{
            //    System.IO.File.Delete(removing);
            //}

            Order = await _context.Orders.FindAsync(id);

            if (Order != null)
            {
                _context.Orders.Remove(Order);
                await _context.SaveChangesAsync();
            }
            if (role == "Admin" || role == "Master")
            {
                return RedirectToPage("./OrderTable");
            }
            else
            {
                return RedirectToPage("./OrderCustomerTable");
            }
            
        }
    }
}