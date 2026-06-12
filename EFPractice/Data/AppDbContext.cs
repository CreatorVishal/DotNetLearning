
using EFPractice.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees150 { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=EmployeeDb150;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Employee>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(x => x.Age)
                .HasDefaultValue(18);

            modelBuilder.Entity<Employee>()
                .Property(x => x.Salary)
                .HasColumnType("decimal(18,2)");

            //new
            modelBuilder.Entity<Employee>()
    .HasOne(x => x.Department)
    .WithMany(x => x.Employees)
    .HasForeignKey(x => x.DepartmentId);
        }
    }
}