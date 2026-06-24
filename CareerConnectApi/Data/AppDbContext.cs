using CareerConnectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CareerConnectApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }
        public DbSet<Job> Jobs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Application> Applications { get; set; }

    }
}
