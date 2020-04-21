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
        public RazorPagesTutorial.Models.Orders Or { get; set; }
        [BindProperty]
        public Product P { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Or = await _context.Orders.FirstOrDefaultAsync(m => m.O_ID == id);
            P = await _context.Product.FirstOrDefaultAsync(m => m.P_ID == Or.O_PIDS);
            
            if (Or != null)
            {
                P.P_Amount = P.P_Amount + 1;
                _context.Orders.Remove(Or);
                _context.Attach(P).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./OrderCustomerTable");
        }
    }
}