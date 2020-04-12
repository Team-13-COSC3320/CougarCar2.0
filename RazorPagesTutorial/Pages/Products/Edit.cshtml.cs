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

namespace RazorPagesTutorial.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;
        private IWebHostEnvironment _environment;

        public EditModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.P_ID == id);

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
                if(Upload != null)
                {
                DateTime currentTime = DateTime.Now;
                string h = currentTime.Hour.ToString();
                string m = currentTime.Minute.ToString();
                string s = currentTime.Second.ToString();
                string time = "-" + currentTime.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
                string hms = "-" + h + "-" + m + "-" + s + "-";
                var fileName = Path.GetFileNameWithoutExtension(Upload.FileName) + time + hms + Path.GetExtension(Upload.FileName);
                var file = Path.Combine(_environment.WebRootPath, "Images", fileName);

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                Product.P_Image = "/Images/" + Path.GetFileName(fileName);
                }
                
            }
            _context.Attach(Product).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.P_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.P_ID == id);
        }
    }
}
