using Microsoft.EntityFrameworkCore;

namespace MovieCatalogAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data
            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, Name = "Christopher Nolan" },
                new Director { Id = 2, Name = "Quentin Tarantino" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", ReleaseYear = 2010, DirectorId = 1 },
                new Movie { Id = 2, Title = "Pulp Fiction", ReleaseYear = 1994, DirectorId = 2 }
            );
        }
    }
}