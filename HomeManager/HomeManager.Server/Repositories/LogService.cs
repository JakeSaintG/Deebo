using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.Server.Repositories;

public class LogService
{
    // Create a new log entry
    public async Task<LogEntry> CreateLogEntryAsync(string name, string? email)
    {
        using var dbContext = DbContextFactory.Create();

        var log = new LogEntry
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email
        };

        dbContext.LogEntries.Add(log);
        await dbContext.SaveChangesAsync();

        return log;
    }

    // Get a log entry by ID
    public async Task<LogEntry?> GetLogEntryByIdAsync(Guid id)
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.LogEntries.FindAsync(id);
    }

    // Get all log entries
    public async Task<List<LogEntry>> GetAllLogEntriessAsync()
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.LogEntries.ToListAsync();
    }

    // Update a log entry
    public async Task<LogEntry?> AckLogEntryAsync(Guid id, string name, string? email)
    {
        using var dbContext = DbContextFactory.Create();

        var log = await dbContext.LogEntries.FindAsync(id);
        if (log == null)
        {
            return null;
        }

        log.Name = name;
        log.Email = email;

        await dbContext.SaveChangesAsync();

        return log;
    }

    // Delete a log entry (not implemented)
}
