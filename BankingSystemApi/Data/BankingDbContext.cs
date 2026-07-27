using BankingSystemApi.Models;
using Microsoft.EntityFrameworkCore;
namespace BankingSystemApi.Data
{
    public class BankingDbContext: DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext>options):base(options)
        {


        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
