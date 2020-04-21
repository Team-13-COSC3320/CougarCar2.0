using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LibraryData.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Data;
using Microsoft.AspNetCore.Http;

namespace RazorPagesTutorial
{
    public class IndexModel : PageModel
    {
        public readonly RazorPagesTutorialContext _context;
        
        List<string> imagefiles;
        List<int> product_ids;
        public string current_image;
        public int review_pid;

        void set_imagefiles() {
            imagefiles = new List<string>();
            product_ids = new List<int>();
            foreach (Product i in _context.Product)
            {
                if (i.P_Image == null)
                {
                    imagefiles.Add("no-image.jpg");
                }
                else imagefiles.Add(i.P_Image.ToString());
                product_ids.Add(i.P_ID);
            }
            byte[] str = HttpContext.Session.Get("Index");
            string index  = Encoding.UTF8.GetString(str, 0, str.Length);
            current_image = imagefiles[int.Parse(index)];
            validReviews = _context.GetReviewsOnProduct(product_ids[int.Parse(index)]);
        }
        public IndexModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }
        public List<Review> validReviews { get; private set; }

        public void OnGet()
        {
            HttpContext.Session.SetString("Index", "0");
            byte[] str;
            if (HttpContext.Session.Get("Id") != null)
            {
                str = HttpContext.Session.Get("Id");
                string ID = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["Userid"] = ID;
            }
            if (HttpContext.Session.Get("Role") != null)
            {
                str = HttpContext.Session.Get("Role");
                string Role = Encoding.UTF8.GetString(str, 0, str.Length);
                ViewData["UserRole"] = Role;
            }
            set_imagefiles();
            
        }

        public void OnPost(string side)
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
            set_imagefiles();
            if (side.Contains("Right"))
            {
                byte[] str = HttpContext.Session.Get("Index");
                string index = Encoding.UTF8.GetString(str, 0, str.Length);
                int test = int.Parse(index) + 1;
                if(test == imagefiles.Count())
                {
                    test = 0;
                }
                HttpContext.Session.SetString("Index", test.ToString());
                current_image = imagefiles[test];
                validReviews = _context.GetReviewsOnProduct(product_ids[test]);
                review_pid = test;
            }
            else if (side.Contains("Left"))
            {
                byte[] str = HttpContext.Session.Get("Index");
                string index = Encoding.UTF8.GetString(str, 0, str.Length);
                int test = int.Parse(index) - 1;
                if(test == -1)
                {
                    test = imagefiles.Count()-1;
                }
                HttpContext.Session.SetString("Index", test.ToString());
                current_image = imagefiles[test];
                validReviews = _context.GetReviewsOnProduct(product_ids[test]);
                review_pid = test;
            }
        }

    }
}
