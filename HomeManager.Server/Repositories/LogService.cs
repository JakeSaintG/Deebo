using HomeManager.Server.Context;
using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeManager.Server.Repositories;

public class LogService
{
    public async void Log (string message, string level = "INFO")
    {
        await CreateLogEntryAsync(
            id: null,
            logLevel: level,
            logSource: "internal",
            logDts: null,
            logMessage: message
        );
    }
    
    public async Task<LogEntry> CreateLogEntryAsync(Guid? id, string logLevel, string logSource, DateTime? logDts, string? logMessage)
    {
        // TODO: I don't like this... Should probably always assign a guid
        // Maybe add an "idFromLogSource" field
        Guid idAsGuid = (Guid)(id != null ? id : Guid.NewGuid());
        DateTime logTime = (DateTime)(logDts != null ? logDts : DateTime.UtcNow);

        using var dbContext = DbContextFactory.Create();

        var log = new LogEntry
        {
            Id = idAsGuid,
            LogLevel = logLevel,
            LogSource = logSource,
            LogDts = logTime,
            LastModifiedDts = DateTime.UtcNow,
            LogMessage = logMessage,
            Consumed = false,
        };

        dbContext.LogEntries.Add(log);
        await dbContext.SaveChangesAsync();

        return log;
    }

    public async Task<LogEntry?> GetLogEntryByIdAsync(Guid id)
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.LogEntries.FindAsync(id);
    }

    public async Task<List<LogEntry>> GetAllLogEntriesAsync()
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.LogEntries.ToListAsync();
    }

    public async Task<LogEntry?> AckLogEntryAsync(Guid id, bool consumed)
    {
        using var dbContext = DbContextFactory.Create();

        var log = await dbContext.LogEntries.FindAsync(id);
        if (log == null) return null;

        log.Consumed = consumed;

        await dbContext.SaveChangesAsync();

        return log;
    }
}
