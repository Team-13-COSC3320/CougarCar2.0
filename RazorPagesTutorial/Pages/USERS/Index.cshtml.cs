using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Pages.USERS
{
    public class IndexModel2 : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public IndexModel2(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public IList<USER> USERS { get; set; }
        //public LoginUSER CurrentUser { get; set; }
        public int currentID;

        public async Task OnGetAsync(int? id)
        {
            USERS = await _context.USERS.ToListAsync();

            //CurrentUser = await _context.LoginUSER.FirstOrDefaultAsync(m => m.U_ID == id);
            for (int i = 0; i < USERS.Count(); i++)
            {
                //Msg1 = "In";

                //ID;s validation
                if (USERS[i].U_ID == id)
                {
                    currentID = USERS[i].U_ID - 1;//-1 because ID start from 1, but list is start from 0
                }
            }

        }
    }
}
