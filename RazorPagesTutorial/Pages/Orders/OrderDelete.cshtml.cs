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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Or = await _context.Orders.FirstOrDefaultAsync(m => m.O_ID == id);
            if (Or != null)
            {
                _context.Orders.Remove(Or);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./OrderCustomerTable");
        }
    }
}