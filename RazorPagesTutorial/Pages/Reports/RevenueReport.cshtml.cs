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
    public class RevenueReportModel : PageModel
    {
        private readonly RazorPagesTutorialContext _context;


        public RevenueReportModel()
        {
            _context = new RazorPagesTutorialContext();
        }
        [BindProperty]
        public DateTime date { get; set; }
       
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
            cmd = new SqlCommand("RevenueReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date1", SqlDbType.DateTime).Value = DateTime.Now;

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dataSet = ds;
            con.Close();

            //Console.Out.Write(dataSet.Tables[0].Columns[0].ToString());

            return Page();
        }

        public async Task OnPostAsync()
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
            if (Request.Form["dateSelected"].ToString().Length == 0)
            {
                date = DateTime.Parse("04-01-2020");
            }else date = DateTime.Parse(Request.Form["dateSelected"]);
            if (date == DateTime.MinValue)
            {
                date = DateTime.Parse("04-01-2020");
            }
            

            Console.Out.Write(date);

            SqlConnection con = new SqlConnection("Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("RevenueReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date1", SqlDbType.DateTime).Value = date;

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dataSet = ds;
            con.Close();
        }


        /* SqlConnection con = new SqlConnection("Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("RevenueReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Date1", SqlDbType.DateTime).Value = DateTime.Now;

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dataSet = ds;
            con.Close();
         */


    }
}