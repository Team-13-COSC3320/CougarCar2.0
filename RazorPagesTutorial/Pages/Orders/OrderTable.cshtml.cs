using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesTutorial
{
    public class OrderTableModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;

        public OrderTableModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public IList<Orders> Orders { get; set; }

        public async Task OnGetAsync()
        {
            Orders = await _context.Orders.ToListAsync();
        }

    }
}