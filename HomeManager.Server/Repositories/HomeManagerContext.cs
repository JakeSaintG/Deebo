using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.Server.Repositories;

using Microsoft.EntityFrameworkCore;

public class HomeManagerContext : DbContext
{
     // DbSet for the User model
    public DbSet<User> Users { get; set; }
     // DbSet for the User model

    public DbSet<LogEntry> LogEntries { get; set; }

    public HomeManagerContext(DbContextOptions<HomeManagerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the table name for the User entity
        modelBuilder.Entity<User>().ToTable("Users");

        // Optional: Add additional configurations (e.g., primary key, indexes)
        modelBuilder.Entity<User>().HasKey(u => u.Id);

        // Configure the table name for the User entity
        modelBuilder.Entity<LogEntry>().ToTable("LogEntries");

        // Optional: Add additional configurations (e.g., primary key, indexes)
        modelBuilder.Entity<LogEntry>().HasKey(l => l.Id);
    }
}
