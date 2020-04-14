using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using RazorPagesTutorial.Data;
using System.Text;

namespace RazorPagesTutorial
{
    public class ReviewTableModel : PageModel
    {

        RazorPagesTutorialContext _context { get; set; }
        public IList<Review> Review { get; private set; }

        public ReviewTableModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }
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
            Review = await _context.Review.ToListAsync();
        }
    }
}