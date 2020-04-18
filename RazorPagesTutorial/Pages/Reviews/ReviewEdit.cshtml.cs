using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;
using RazorPagesTutorial.Data;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace RazorPagesTutorial
{
    public class ReviewEditModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public ReviewEditModel(RazorPagesTutorialContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review{ get; set; }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
            Review = await _context.Review.FirstOrDefaultAsync(m => m.R_ID == id);
            Product = await _context.Product.FirstOrDefaultAsync(m => m.P_ID == Review.ID);
            
            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
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

            if (!ModelState.IsValid)
            {
                return Page();
            }



            
            string connection = "Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connection);

            string query = "Update dbo.Review " +
                            "Set " +
                            "R_Title = @R_TITLE, R_Content = @R_CONTENT, R_Star = @R_STAR " +
                            "Where R_ID = @R_ID AND R_UID = @R_UID"; //+
                                                                     //Console.Out.Write(ViewData["Userid"]);
                                                                     //if(ViewData["Userid"] == null)
                                                                     //{
                                                                     //    Console.Out.Write("null");
                                                                     //}
            //Console.WriteLine();
            var content = Review.R_Content;
            var title = Review.R_Title;
            var star = Review.R_Star;
            var ruid = Review.R_UID;
            var rid = Review.R_ID;
            //string userid = ViewData["Userid"].ToString(); //null
            Console.Out.Write(ViewData["Userid"]);
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.Add("@R_TITLE", SqlDbType.Char).Value = title;
            cmd.Parameters.Add("@R_Content", SqlDbType.Char).Value = content;
            cmd.Parameters.Add("@R_Star", SqlDbType.Int).Value = star;
            cmd.Parameters.Add("@R_ID", SqlDbType.Int).Value = rid;

            cmd.Parameters.Add("@R_UID", SqlDbType.Int); //ViewData["Userid"]
            cmd.Parameters["@R_UID"].Value = Int32.Parse(ViewData["Userid"].ToString());

            // only works if we assume that only the person
            // who created the review can edit the review

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            Review = await _context.Review.FirstOrDefaultAsync(m => m.R_ID == id);
            //_context.Attach(Review).State = EntityState.Modified;

            try
            {
                Console.Out.Write(Review.R_ID);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.R_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //If admin do this
            if (ViewData["UserRole"].ToString().Contains("Master") || ViewData["UserRole"].ToString().Contains("Admin"))
            {
                return RedirectToPage("./ReviewTable");
            }
            else //If not admin
            {
                return RedirectToPage("/Products/ProductList");
            }
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.R_ID == id);
        }

    }
}