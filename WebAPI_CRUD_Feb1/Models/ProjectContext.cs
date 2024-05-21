using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace WebAPI_CRUD_Feb1.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> option):base(option)
        {
            
        }
        public DbSet<Product> tblProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product { PId = 1, PName = "Mobile", Price = 19000, DOP = new DateTime(2000, 3, 29) },
            new Product { PId = 2, PName = "TV", Price = 30000, DOP = new DateTime(2020, 1, 30) }
         );
        }
    }
}
