using ConsoleDBTest.Models;
using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.Server.Repositories;

public class HomeManagerContext : DbContext
{
    private DbSet<TestSet> _testSetContext { get; set; }

    public HomeManagerContext(DbContextOptions<HomeManagerContext> options) : base(options)
    {
        Console.WriteLine("WE DOIN IT!");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //TODO: Need to use appSettings
            optionsBuilder.UseSqlite($"Data Source=./HomeManager.db;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestSet>().ToTable("TestSet");
    }

    public void ShowAllRows()
    {
        _testSetContext.ToList().ForEach(h =>
        {
            Console.WriteLine($"- {h.Id}: {h.Column1}; {h.Column2}");
        });
    }

    public TestSet? GetRowById(string id)
    {
        return _testSetContext.SingleOrDefault(s => s.Id == id);
    }

    public void AddTestRow()
    {
        TestSet foo = new TestSet
        {
            Id = Guid.NewGuid().ToString(),
            Column1 = "test",
            Column2 = "test as well"
        };

        _testSetContext.Add(foo);
        // _testSetContext.SaveChanges();
    }
}
