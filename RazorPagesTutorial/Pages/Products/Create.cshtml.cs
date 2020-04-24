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
using System.Data;
using System.Data.SqlClient;

namespace RazorPagesTutorial.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;
        private IWebHostEnvironment _environment;

        public CreateModel(RazorPagesTutorialContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
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
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<Product> plist = _context.getProductList();

            if (Upload != null)
            {
                var fileName = plist[plist.Count() - 1].P_ID.ToString() + Path.GetExtension(Upload.FileName);
                var file = Path.Combine(_environment.WebRootPath, "Images", fileName);

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                Product.P_Image = Path.GetFileName(fileName);
            }

            SqlConnection sqlConnection = new SqlConnection(_context.connection);
            SqlCommand cmd = new SqlCommand("dbo.add_Product", sqlConnection);
            
            cmd.Parameters.Add("@p_name", SqlDbType.Char).Value = Product.P_Name;
            cmd.Parameters.Add("@p_cat", SqlDbType.Char).Value = Product.P_Category;
            if (Product.P_Image == null)
                Product.P_Image = "no-image.jpg";
            cmd.Parameters.Add("@p_img", SqlDbType.VarChar).Value = Product.P_Image;
            if (Product.P_Price == null)
                Product.P_Price = 0;
            cmd.Parameters.Add("@p_price", SqlDbType.Int).Value = Product.P_Price;
            if (Product.P_Description == null)
                Product.P_Description = "";
            cmd.Parameters.Add("@p_desc", SqlDbType.VarChar).Value = Product.P_Description;
            if (Product.P_Amount == null)
                Product.P_Amount = 5;
            cmd.Parameters.Add("@p_amount", SqlDbType.Int).Value = Product.P_Amount;
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return RedirectToPage("./Index");
        }
    }
}
