using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using LibraryData.Models;
using RazorPagesTutorial.Data;

namespace RazorPagesTutorial.Pages.Reports
{
    public class ReviewReportModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;


        public ReviewReportModel()
        {
            _context = new RazorPagesTutorialContext();
        }

        public int star, currentUserID, count;

        public IList<USER> USERS { get; set; }

        public IList<Review> REVIEW { get; set; }

        public IList<Product> PRODUCTS { get; set; }

        public async Task OnGetAsync(int? id)
        {
            if (HttpContext.Session.Get("Id") != null)
            {
                byte[] str = HttpContext.Session.Get("Id");
                string ID = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["Userid"] = ID;
                //Console.Out.Write(ViewData["Userid"]);
            }
            if (HttpContext.Session.Get("Role") != null)
            {
                byte[] str = HttpContext.Session.Get("Role");
                string Role = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["UserRole"] = Role;

            }
            USERS = _context.getUserList();
            REVIEW = _context.getReviewList();
            PRODUCTS = _context.getProductList();
            count = REVIEW.Count();
            for (int i = 0; i < USERS.Count(); i++)
            {
                //Msg1 = "In";

                //ID;s validation
                if (USERS[i].U_ID == id)
                {
                    currentUserID = USERS[i].U_ID - 1;//-1 because ID start from 1, but list is start from 0
                }
            }
        }

        public async Task OnPostAsync()
        {
            if (HttpContext.Session.Get("Id") != null)
            {
                byte[] str = HttpContext.Session.Get("Id");
                string ID = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["Userid"] = ID;
                //Console.Out.Write(ViewData["Userid"]);
            }
            if (HttpContext.Session.Get("Role") != null)
            {
                byte[] str = HttpContext.Session.Get("Role");
                string Role = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["UserRole"] = Role;

            }
            USERS = _context.getUserList();
            REVIEW = _context.getReviewList();
            PRODUCTS = _context.getProductList();
            star = int.Parse( Request.Form["starSelected"]);
            count = 0;
            foreach (Review i in REVIEW)
            {
                if (i.R_Star == star || star == 0)
                {
                    count += 1;
                }
            }
        }
    }
}