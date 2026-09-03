using Microsoft.EntityFrameworkCore;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Data
{
    public class PeopleConnectDbContext : DbContext
    {
        public PeopleConnectDbContext(DbContextOptions<PeopleConnectDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Peoples { get; set; }

    }
}
