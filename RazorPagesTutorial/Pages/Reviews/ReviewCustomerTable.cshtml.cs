using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTutorial
{
    public class ReviewCustomerTableModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;
        public IList<Review> Reviews { get; set; }

        public ReviewCustomerTableModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
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

            Reviews = _context.GetReviewsFromUser(Int32.Parse(ViewData["Userid"].ToString()));
        }
        //GetReviewsFromUser
    }
}