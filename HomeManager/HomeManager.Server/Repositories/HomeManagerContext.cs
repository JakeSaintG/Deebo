using ConsoleDBTest.Models;
using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.Server.Repositories;

public class HomeMangerContext : DbContext
{
    private DbSet<TestSet> _testSetContext { get; set; }

    public HomeMangerContext() : base() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: Need to use appSettings
        optionsBuilder.UseSqlite($"Data Source=./HomeManager.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestSet>().ToTable("TestSet");
    }

    public void ShowAllCatchPhrases()
    {
        _testSetContext.ToList().ForEach(h =>
        {
            Console.WriteLine($"- {h.Id}: {h.Column1}; {h.Column2}");
        });
    }

    public TestSet? GetHeroById(string id)
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
        _testSetContext.SaveChanges();
    }
}
