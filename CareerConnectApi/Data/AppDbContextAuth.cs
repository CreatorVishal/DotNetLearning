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
}
