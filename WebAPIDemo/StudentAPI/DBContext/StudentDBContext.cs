using Microsoft.EntityFrameworkCore;
using StudentAPI.DBContext.Configuration;
using StudentAPI.Models;

namespace StudentAPI.DBContext
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions options):base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
        public DbSet<Student>students { get; set; }
    }
}
