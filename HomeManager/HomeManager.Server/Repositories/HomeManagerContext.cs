using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.Server.Repositories;

using Microsoft.EntityFrameworkCore;

public class HomeManagerContext : DbContext
{
    public DbSet<User> Users { get; set; }
     // DbSet for the User model
    public HomeManagerContext(DbContextOptions<HomeManagerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the table name for the User entity
        modelBuilder.Entity<User>().ToTable("Users");

        // Optional: Add additional configurations (e.g., primary key, indexes)
        modelBuilder.Entity<User>().HasKey(u => u.Id);
    }
}
