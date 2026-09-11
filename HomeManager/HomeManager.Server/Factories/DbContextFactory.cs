using HomeManager.Server.Repositories;
using Microsoft.EntityFrameworkCore;

public static class DbContextFactory
{
    public static HomeManagerContext Create()
    {
        var optionsBuilder = new DbContextOptionsBuilder<HomeManagerContext>();
        optionsBuilder.UseSqlite($"Data Source=./HomeManager.db;");
        return new HomeManagerContext(optionsBuilder.Options);
    }
}