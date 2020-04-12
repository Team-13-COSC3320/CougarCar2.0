using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RazorPagesTutorial.Data
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment he;
        public HomeController(IWebHostEnvironment e)
        {
            he = e;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowFields(IFormFile pic)
        {
            if(pic != null)
            {
                var fileName = Path.Combine(he.WebRootPath+"Images"+Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["fileLocation"] = "/" + Path.GetFileName(pic.FileName);

            }
            return View();
        }
    }
}
