using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Data
{
    //public class PeopleConnectDbContext : DbContext
    public class PeopleConnectDbContext: IdentityDbContext<ApplicationUser>
    {
        public PeopleConnectDbContext(DbContextOptions<PeopleConnectDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
