using CareerConnectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CareerConnectApi.Data;

public class AppDbContextAuth : DbContext
{
    public AppDbContextAuth(DbContextOptions<AppDbContextAuth> options)
        : base(options)
    {

    }
    //public DbSet<User> UsersData => Set<User>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<UserAccount> UserAccounts => Set<UserAccount>();
    public DbSet<RefreshToken> RefreshTokens=>Set<RefreshToken>();
}
