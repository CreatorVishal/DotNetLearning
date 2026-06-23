using GymManagementApi.Models;
using Microsoft.EntityFrameworkCore;


 namespace GymManagementApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer>Trainers{ get; set; }
    }
}
