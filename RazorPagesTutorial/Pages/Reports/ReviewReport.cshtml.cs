using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Http;
using LibraryData.Models;
using RazorPagesTutorial.Data;

namespace WebApplication3.Pages.Reports
{
    public class ReviewReportModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;


        public ReviewReportModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public int star, currentUserID;

        public IList<USER> USERS { get; set; }

        public IList<Review> REVIEW { get; set; }

        public IList<Product> PRODUCTS { get; set; }

        public async Task OnGetAsync(int? id)
        {
            
            USERS = await _context.USERS.ToListAsync();
            REVIEW = await _context.Review.ToListAsync();
            PRODUCTS = await _context.Product.ToListAsync();

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
            USERS = await _context.USERS.ToListAsync();
            REVIEW = await _context.Review.ToListAsync();
            PRODUCTS = await _context.Product.ToListAsync();
            star = int.Parse( Request.Form["starSelected"]);
        }
    }
}