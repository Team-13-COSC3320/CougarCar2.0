using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RazorPagesTutorial.Data;
using Microsoft.AspNetCore.Http;

namespace RazorPagesTutorial.Pages.USERS
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginUSER LOGIN_USER { get; set; }
        public IList<USER> USERS { get; set; }

        public string Msg, Msg1, url;
        //public int id;

        private readonly RazorPagesTutorialContext _context;

        public LoginModel(RazorPagesTutorialContext context)
        {
            _context = context;

        }
        /*
        public async Task OnGetAsync()
        {
            Msg = "in OnGetAsync()";
            USERS = await _context.USERS.ToListAsync();

        }*/
        
        public async Task<IActionResult> OnPost(int? id)
        {
            //Msg = "in OnPostAsync()";

            //_context.LoginUSER.Add(USER);
            USERS = await _context.USERS.ToListAsync();
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            
            for (int i = 0; i < USERS.Count(); i++)
            {
                //Msg1 = "In";

                //ID;s validation
                if (USERS[i].U_ID == LOGIN_USER.U_ID)
                {
                    //Msg = item.U_ID.ToString();
                    //Msg1 = USER.U_ID.ToString();

                    //Password's validation
                    //USER.U_Pass.Contains(USERS[i].U_Pass)
                    if (LOGIN_USER.U_Pass==USERS[i].U_Pass.Trim())
                    {
                        //matched - get all needed infos
                        LOGIN_USER.U_ID = USERS[i].U_ID;
                        //id = USER.U_ID;//Set for route
                        LOGIN_USER.U_LName = USERS[i].U_LName;
                        LOGIN_USER.U_Pass = USERS[i].U_Pass;
                        LOGIN_USER.U_Role = USERS[i].U_Role;
                        //Start redirect user by ROLE
                        HttpContext.Session.SetString("Id",LOGIN_USER.U_ID.ToString());
                        if (USERS[i].U_Role.Contains("Customer"))
                        {
                            url = "../USERS/CustomerAccountMm?id=" + LOGIN_USER.U_ID.ToString();
                            return Redirect(url);//go back to homepage/product view for customer
                        }
                        else
                        {
                            url = "../USERS/Index?id=" + LOGIN_USER.U_ID.ToString();
                            //mean this user is master/admin role
                            //return RedirectToPage(url);//go to users management/view page
                            //"./Details?id=" + LOGIN_USER.U_ID.ToString()
                            return Redirect(url);
                            
                            //return RedirectToPage("./Index");
                        }
                    }
                    else
                    {
                        //mean ID or password doesnt matched
                        return Page();
                    }
                }
            }

            //Msg1 = "outside foreach "+ USER.U_ID.ToString();

            return Page();

            //USERS = await _context.USERS.ToListAsync();
            
        }


    }
}