using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Data;
using RazorPagesTutorial.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RazorPagesTutorial.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        private IWebHostEnvironment _environment;

        public EditModel(RazorPagesTutorialContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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
            Product = await _context.Product.FirstOrDefaultAsync(m => m.P_ID == id);
            Id = id;
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ModelState.IsValid)
            {
                if (Upload != null)
                {

                    var fileName = Product.P_ID.ToString() + Path.GetExtension(Upload.FileName);
                    var file = Path.Combine(_environment.WebRootPath, "Images", fileName);

                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await Upload.CopyToAsync(fileStream);
                    }

                    Product.P_Image = Path.GetFileName(fileName);
                }
                
            }
            _context.Attach(Product).State = EntityState.Modified;

            string connection = "Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connection);

            string query = "Update dbo.Products " +
                            "Set " +
                            "P_Name = @P_Name, P_Category = @P_Category, P_Image = @P_Image, P_Price = @P_Price, P_Description = @P_Description, P_Amount = @P_Amount " +
                            "Where P_ID = @P_ID"; //+
            
            var name = Product.P_Name;
            var cat = Product.P_Category;

            
           
            var price = Product.P_Price;
            var desc = Product.P_Description;
            var amount = Product.P_Amount;
            var image = Product.P_Image;
            if (image == null)
            {
                Product = _context.getProduct(Product.P_ID);
                image = Product.P_Image;
            }

            Console.Out.Write(ViewData["Userid"]);
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.Add("@P_Name", SqlDbType.Char).Value = name;
            cmd.Parameters.Add("@P_Category", SqlDbType.Char).Value = cat;
            cmd.Parameters.Add("@P_Image", SqlDbType.Char).Value = image;
            cmd.Parameters.Add("@P_Price", SqlDbType.Int).Value = price;
            cmd.Parameters.Add("@P_Description", SqlDbType.Char).Value = desc;
            cmd.Parameters.Add("@P_Amount", SqlDbType.Int).Value = amount;

            cmd.Parameters.Add("@P_ID", SqlDbType.Int); //ViewData["Userid"]
            cmd.Parameters["@P_ID"].Value = Product.P_ID;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();



            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.P_ID == id);
        }
    }
}
