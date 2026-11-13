using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.Server.Context;

using Microsoft.EntityFrameworkCore;

public class HomeManagerContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }
    public DbSet<BotConfiguration> BotConfiguration { get; set; }

    public HomeManagerContext(DbContextOptions<HomeManagerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the table for entity: Users
        modelBuilder.Entity<User>().ToTable("Users");
        // Additional configurations (e.g., primary key, indexes)
        modelBuilder.Entity<User>(entity => entity.HasKey(u => u.Id));

        // Configure the table for entity: LogEntries
        modelBuilder.Entity<LogEntry>().ToTable("LogEntries");

        // Configure the table for entity: BotConfiguration
        modelBuilder.Entity<BotConfiguration>().ToTable("BotConfiguration");
        // Additional configurations (e.g., primary key, indexes)
        modelBuilder.Entity<BotConfiguration>(entity => entity.HasKey(l => l.BotId));
    }
}
