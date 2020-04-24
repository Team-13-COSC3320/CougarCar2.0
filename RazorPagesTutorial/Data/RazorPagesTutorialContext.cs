using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryData.Models;
using RazorPagesTutorial.Models;
using System.Data;
using System.Data.SqlClient;

namespace RazorPagesTutorial.Data
{
    public class RazorPagesTutorialContext : DbContext
    {
        public RazorPagesTutorialContext(DbContextOptions<RazorPagesTutorialContext> options)
            : base(options)
        {
        }

        public string connection = "Data Source=sql5053.site4now.net;User ID=DB_A573D4_team13_admin;Password=Team13shop;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DbSet<RazorPagesTutorial.Models.Product> Product { get; set; }
        public DbSet<RazorPagesTutorial.Models.Orders> Orders { get; set; }
        public DbSet<RazorPagesTutorial.Models.USER> USERS { get; set; }
        public DbSet<RazorPagesTutorial.Models.LoginUSER> LoginUSER { get; set; }
        public DbSet<Review> Review {get; set;}
        public int Userid { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("PRODUCTS");
            modelBuilder.Entity<Review>().ToTable("REVIEW");
            modelBuilder.Entity<Orders>().ToTable("ORDERS");
            modelBuilder.Entity<USER>().ToTable("USERS");
        }

        internal List<Review> GetReviewsOnProduct(int? id)
        {
            List<Review> validReviews = new List<Review>();
            foreach (Review r in Review)
            {
                if (r.ID == id)
                {
                    validReviews.Add(r);
                }
            }

            return validReviews;
        }

        internal List<Orders> GetOrderFromUser(int? id)
        {
            List<Orders> validOrders = new List<Orders>();
            foreach(Orders o in Orders)
            {
                if(id == o.O_UID)
                {
                    validOrders.Add(o);
                }
            }
            return validOrders;
        }

        internal List<Review> GetReviewsFromUser(int? id)
        {
            List<Review> validreviews = new List<Review>();
            foreach (Review r in Review)
            {
                if (id == r.R_UID)
                {
                    validreviews.Add(r);
                }
            }
            return validreviews;
        }

        internal Orders getOrder(int id)
        {
            Orders Or = new Orders();
            
            SqlConnection sqlConnection = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand("dbo.get_Order", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            sqlConnection.Open();
            Console.SetOut(new DebugTextWriter());
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0].ToString());
                    Or.O_ID = rdr.GetInt32(0);
                    Console.WriteLine(Or.O_ID.ToString());
                    Or.O_Date = rdr.GetDateTime(1);
                    Or.O_UID = rdr.GetInt32(2);
                    Or.O_PIDS = rdr.GetInt32(3);
                    Or.O_Status = rdr.GetString(5);
                    Console.WriteLine(Or.O_Status);
                }
            }
            sqlConnection.Close();
            return Or;
        }
    }
}
