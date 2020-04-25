using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTutorial.Data;


namespace RazorPagesTutorial
{
    public class ReviewAVGReportModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;

        public ReviewAVGReportModel()
        {
            _context = new RazorPagesTutorialContext();
        }


        [BindProperty]
        public DataSet dataSet { get; set; }
        public async Task<IActionResult> OnGetAsync()
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

            SqlConnection con = new SqlConnection("Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("ReviewReportAVG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dataSet = ds;
            con.Close();

            Console.Out.Write(dataSet.Tables[0].Columns[0].ToString());

            return Page();
        }
    }
}