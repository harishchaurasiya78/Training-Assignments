using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed small sample data (optional)
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "William Shakespeare" },
                new Author { AuthorId = 2, Name = "Jane Austen" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Drama" },
                new Genre { GenreId = 2, Name = "Novel" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Hamlet", AuthorId = 1, GenreId = 1, Price = 199.00M },
                new Book { BookId = 2, Title = "Pride and Prejudice", AuthorId = 2, GenreId = 2, Price = 299.00M }
            );
        }
    }
}
