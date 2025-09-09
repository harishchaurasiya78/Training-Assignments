using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;

namespace BookStoreAPI.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.K. Rowling", Email = "jkrowling@email.com" },
                new Author { Id = 2, Name = "George R.R. Martin", Email = "grrmartin@email.com" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 1, PublicationYear = 1997, ISBN = "9780747532743", Price = 19.99m },
                new Book { Id = 2, Title = "A Game of Thrones", AuthorId = 2, PublicationYear = 1996, ISBN = "9780553103540", Price = 24.99m }
            );
        }
    }
}