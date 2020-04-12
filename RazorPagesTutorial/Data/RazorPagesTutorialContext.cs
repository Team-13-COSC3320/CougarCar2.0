using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using RazorPagesTutorial.Models;

namespace RazorPagesTutorial.Data
{
    public class RazorPagesTutorialContext : DbContext
    {
        public RazorPagesTutorialContext(DbContextOptions<RazorPagesTutorialContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTutorial.Models.Product> Product { get; set; }

        public DbSet<RazorPagesTutorial.Models.Orders> Orders { get; set; }

        public DbSet<Review> Review {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("PRODUCTS");
            modelBuilder.Entity<Review>().ToTable("REVIEW");
            modelBuilder.Entity<Orders>().ToTable("ORDERS");
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
    }
}
