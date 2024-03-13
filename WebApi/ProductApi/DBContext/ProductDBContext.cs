
using Microsoft.EntityFrameworkCore;
using ProductApi.DBContext.Configuration;
using ProductApi.Models;

namespace ProductApi.DBContext
{
   
    public class ProductDBContext:DbContext
    {
        public  ProductDBContext(DbContextOptions options):base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        public DbSet<Product> Products { get; set; }
    }
}
