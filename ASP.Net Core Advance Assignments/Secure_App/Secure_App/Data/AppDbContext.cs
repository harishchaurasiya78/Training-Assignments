using Microsoft.EntityFrameworkCore;
using SecureApp.Models;


namespace SecureApp.Data;


public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


public DbSet<User> Users => Set<User>();


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
base.OnModelCreating(modelBuilder);
modelBuilder.Entity<User>()
.HasIndex(u => u.Email)
.IsUnique();


// Prevent mapping of any sensitive computed columns by accident
}
}