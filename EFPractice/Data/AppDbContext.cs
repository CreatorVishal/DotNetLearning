using EFPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=EFCoreDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}