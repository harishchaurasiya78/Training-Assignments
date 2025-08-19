using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyRazorPagesApp.Models; // Add this line

namespace MyRazorPagesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add these two lines
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}