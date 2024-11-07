using Microsoft.EntityFrameworkCore;
using BookTrail.Models;

namespace BookTrail.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //inserting the data using Entity Framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Title = "Godan",
                    Author = "Munshi Premchand",
                    Description = "Best Hindi Novel",
                    ISBN = "MPC99999901",
                    ListPrice = 199,
                    Price = 190,
                    Price50 = 170,
                    Price100 = 150,
                    CategoryId = 2,
                    ImageUrl = ""
                }
                );
        }
    }
}
