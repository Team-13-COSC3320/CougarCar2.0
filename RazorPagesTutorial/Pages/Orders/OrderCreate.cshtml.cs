using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial
{
    public class OrderCreateModel : PageModel
    {
        private readonly RazorPagesTutorial.Data.RazorPagesTutorialContext _context;

        public OrderCreateModel(RazorPagesTutorial.Data.RazorPagesTutorialContext context)
        {
            _context = context;
        }

        public Orders Order { get; set; }

        

        public Product Product { get; set; }

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


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }




            //_context.Review.FromSqlInterpolated(
            //     $"USE [DB_A573D4_team13] GO " +
            //     $"DECLARE	@return_value int " +
            //     $"EXEC	@return_value = [dbo].[ReviewMasterInsertUpdateDelete] " +
            //     $"@R_ID = {rid}, " +
            //     $"@R_UID = {userid}, " +
            //     $"@R_TITLE = N'{title}', " +
            //     $"@R_CONTENT = N'{content}', " +
            //     $"@R_STAR = {star}, " +
            //     $"@StatementType = N'Insert', " +
            //     $"@ID = {pid} "
            //     +
            //     $"SELECT 'Return Value' = @return_value "
            //     +
            //     $"GO "
            //    );
            // $"USE [DB_A573D4_team13] GO DECLARE	@return_value int EXEC	@return_value = [dbo].[ReviewMasterInsertUpdateDelete] @R_ID = {rid}, @R_UID = {userid}, @R_TITLE = N'{title}', @R_CONTENT = N'{content}', @R_STAR = {star}, @StatementType = N'Insert', @ID = {pid} SELECT 'Return Value' = @return_value GO");
            //_context.Review.FromSqlRaw(
            //    "ReviewMasterInsertUpdateDelete @p1,@p2,@p3,@p4,@p5,@p6,@p7", rid, userid, title, content, star, "Insert", pid);

            //string connection = "Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //SqlConnection sqlConnection = new SqlConnection(connection);

            //string query = "Insert into dbo.REVIEW" +

            //            " (R_UID, R_Title, R_Content, R_Star, ID)  " +

            //            "VALUES(@R_UID, @R_Title, @R_Content, @R_Star, @ID)";

            //SqlCommand cmd = new SqlCommand(query, sqlConnection);
            //cmd.Parameters.Add("@R_UID", SqlDbType.Int).Value = userid;

            //cmd.Parameters.Add("@R_Title", SqlDbType.Char).Value = title;

            //cmd.Parameters.Add("@R_Content", SqlDbType.Char).Value = content;

            //cmd.Parameters.Add("@R_Star", SqlDbType.Int).Value = star;

            //cmd.Parameters.Add("@ID", SqlDbType.Int).Value = pid;

            //sqlConnection.Open();
            //cmd.ExecuteNonQuery();
            //sqlConnection.Close();

            Order.O_Status = "Processing";
            Order.O_Date = DateTime.Now;
            //At some point get UID
            Order.O_UID = 123;
            Order.O_PIDS = Product.P_ID;
            Product.P_Amount--;



            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();


            return RedirectToPage("./ReviewTable");
        }
    }
}