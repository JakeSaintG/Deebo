using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Server.Repositories;

public class LogService
{
    // Create a new user
    public async Task<User> CreateLogEntryAsync(string name, string? email)
    {
        using var dbContext = DbContextFactory.Create();

        var log = new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email
        };

        dbContext.Users.Add(log);
        await dbContext.SaveChangesAsync();

        return log;
    }

    // Get a user by ID
    public async Task<User?> GetLogEntryByIdAsync(Guid id)
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.LogEntries.FindAsync(id);
    }

    // Get all users
    public async Task<List<User>> GetAllLogEntriessAsync()
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.LogEntries.ToListAsync();
    }

    // Update a user
    public async Task<User?> AckLogEntryAsync(Guid id, string name, string? email)
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
