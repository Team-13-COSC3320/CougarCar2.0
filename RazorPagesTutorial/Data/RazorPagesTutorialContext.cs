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
                    Or.O_ID = rdr.GetInt32(0);
                    Or.O_Date = rdr.GetDateTime(1);
                    Or.O_UID = rdr.GetInt32(2);
                    Or.O_PIDS = rdr.GetInt32(3);
                    Or.O_Status = rdr.GetString(5);
                }
            }
            sqlConnection.Close();
            return Or;
        }
        internal Product getProduct(int id)
        {
            Product p = new Product();

            SqlConnection sqlConnection = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand("dbo.get_Product", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            sqlConnection.Open();
            Console.SetOut(new DebugTextWriter());
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    p.P_ID = rdr.GetInt32(0);
                    p.P_Name = rdr.GetString(1);
                    p.P_Category = rdr.GetString(2);
                    p.P_Image = rdr.GetString(3);
                    p.P_Price = rdr.GetInt32(4);
                    p.P_Description = rdr.GetString(5);
                    p.P_Amount = rdr.GetInt32(6);
                }
            }
            sqlConnection.Close();
            return p;
        }
        internal USER getUser(int id)
        {
            USER U = new USER();

            SqlConnection sqlConnection = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand("dbo.get_User", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            sqlConnection.Open();
            Console.SetOut(new DebugTextWriter());
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    U.U_ID = rdr.GetInt32(0);
                    U.U_Pass = rdr.GetString(1);
                    U.U_FName = rdr.GetString(2);
                    U.U_LName = rdr.GetString(3);
                    U.U_Address = rdr.GetString(4);
                    U.U_Country = rdr.GetString(5);
                    U.U_Zipcode = rdr.GetString(6);
                    U.U_Phone = rdr.GetString(7);
                    U.U_Email = rdr.GetString(8);
                    U.U_Role = rdr.GetString(9);
                }
            }
            sqlConnection.Close();
            return U;
        }
        internal List<Product> getProductList()
        {
            List<Product> products = new List<Product>();

            SqlConnection sqlConnection = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand("dbo.get_all_Product", sqlConnection);

            sqlConnection.Open();
            Console.SetOut(new DebugTextWriter());
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Product p = new Product();
                    p.P_ID = rdr.GetInt32(0);
                    p.P_Name = rdr.GetString(1);
                    p.P_Category = rdr.GetString(2);
                    p.P_Image = rdr.GetString(3);
                    p.P_Price = rdr.GetInt32(4);
                    p.P_Description = rdr.GetString(5);
                    p.P_Amount = rdr.GetInt32(6);
                    products.Add(p);
                }
            }
            sqlConnection.Close();
            return products;
        }
        internal List<Orders> getOrderList()
        {
            List<Orders> order = new List<Orders>();

            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("dbo.get_all_Orders", sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Orders o = new Orders();
                    o.O_ID = rdr.GetInt32(0);
                    o.O_Date = rdr.GetDateTime(1);
                    o.O_UID = rdr.GetInt32(2);
                    o.O_PIDS = rdr.GetInt32(3);
                    o.O_Status = rdr.GetString(5);
                    order.Add(o);
                }
            }
            sqlConnection.Close();
            return order;
        }
        internal List<USER> getUserList()
        {
            List<USER> users = new List<USER>();

            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("dbo.get_all_Users", sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    USER U = new USER();
                    U.U_ID = rdr.GetInt32(0);
                    U.U_Pass = rdr.GetString(1);
                    U.U_FName = rdr.GetString(2);
                    U.U_LName = rdr.GetString(3);
                    U.U_Address = rdr.GetString(4);
                    U.U_Country = rdr.GetString(5);
                    U.U_Zipcode = rdr.GetString(6);
                    U.U_Phone = rdr.GetString(7);
                    U.U_Email = rdr.GetString(8);
                    U.U_Role = rdr.GetString(9);
                    users.Add(U);
                }
            }
            sqlConnection.Close();
            return users;
        }
        internal List<Review> getReviewList()
        {
            List<Review> reviews = new List<Review>();

            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("dbo.get_all_Reviews", sqlConnection);

            sqlConnection.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Review r = new Review();
                    r.R_ID = rdr.GetInt32(0);
                    r.R_UID = rdr.GetInt32(1);
                    r.R_Title = rdr.GetString(2);
                    r.R_Content = rdr.GetString(3);
                    r.R_Star = rdr.GetInt32(4);
                    r.ID = rdr.GetInt32(5);
                    reviews.Add(r);
                }
            }
            sqlConnection.Close();
            return reviews;
        }
    }
}
