using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Data;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesTutorial.Pages.USERS
{
    public class LoginCheckModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        private bool checkPass;

        public int ID;
        public string Password;
        public string Msg;

        public LoginCheckModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public IList<USER> USERS  { get; set; }

        public USER USER  { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Msg = "Get in the OnPost";
            /*
            if (int.Parse(Request.Form["ID"]) == 0 || string.IsNullOrEmpty(Request.Form["ID"]))
            {
                Msg = "ID is empty";
                return Page();
                
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Password = Request.Form["Pass"]))
                {

                    Msg = "Password is empty";
                    return Page();
                }
            }*/
            ID = int.Parse(Request.Form["ID"]);
            Password = Request.Form["Pass"];



            var users = from m in _context.USERS select m;
            if (ID > 0)
            {
                users = users.Where(s => s.U_ID.Equals(ID));
                if (users == null)
                {
                    Msg = "Invalid ID";
                }
                else
                {
                    Msg = "";
                }
            }
            USER = _context.getUser(ID);
            if (!string.IsNullOrWhiteSpace(Password) && !(USER == null))
            {
                if (USER.U_Pass.Contains(Password))
                {
                    _context.Userid = ID;
                    if (USER.U_Role.Contains("Customer"))
                    {
                        Msg = "Customer cannot login as Admin";
                        return RedirectToPage("./Pages/Index");
                    }
                    checkPass = true;
                    //return Page();
                    //This mean admin logged in
                    return RedirectToPage("./USERS/Index");
                }
                else
                {
                    checkPass = false;
                    Msg = "Login failed";
                    return Page();
                }
            }
            else
            {
                Msg = "Login failed";
                return Page();
            }
        }
    }
}