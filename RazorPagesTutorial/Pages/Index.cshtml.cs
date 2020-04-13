using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesTutorial.Data;

namespace RazorPagesTutorial.Pages
{
    public class IndexModel : PageModel
    {
        public readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;
        private readonly ILogger<IndexModel> _logger;
        public int User_id;

        public IndexModel(ILogger<IndexModel> logger, RazorPagesTutorialContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            User_id = _context.Userid;
        }

    }
}
