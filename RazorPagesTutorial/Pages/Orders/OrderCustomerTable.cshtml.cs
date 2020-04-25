using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Data;

namespace RazorPagesTutorial
{
    public class OrderCustomerTableModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        public IList<Orders> Orders { get; set; }

        public OrderCustomerTableModel()
        {
            _context = new RazorPagesTutorialContext();
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

            Orders = _context.GetOrderFromUser(Int32.Parse(ViewData["Userid"].ToString()));
        }

    }
}