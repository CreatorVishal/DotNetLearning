using Microsoft.EntityFrameworkCore;
using ReviseEFagain.Entity;

namespace ReviseEFagain.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MovieDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Movie>()
                .Property(x=>x.Title)
                .IsRequired()
                .HasMaxLength(100);
            //// Rating
            //entity.Property(x => x.Rating)
            //      .HasDefaultValue(5);

            //// Column Rename
            //entity.Property(x => x.MovieCode)
            //      .HasColumnName("Movie_Code");

            //// Column Type
            //entity.Property(x => x.Rating)
            //      .HasColumnType("decimal(10,2)");

            //// Ignore Property
            //entity.Ignore(x => x.TempData);
            //--------------------------------------new------------------------------
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieId);
            //-------------------------New------------------------
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.MovieDetail)
                .WithOne(md => md.Movie)
                .HasForeignKey<MovieDetail>(md => md.MovieId);
        }
    }
}