using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Server.Repositories;

public class BotConfigurationService
{
    // public async Task<User> CreateBotConfigAsync()
    // {
    //     using var dbContext = DbContextFactory.Create();

    //     var config = new BotConfiguration
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = name,
    //         Email = email
    //     };

    //     dbContext.Users.Add(user);
    //     await dbContext.SaveChangesAsync();

    //     return user;
    // }

    // public async Task<User?> GetUserByIdAsync(Guid id)
    // {
    //     using var dbContext = DbContextFactory.Create();

    //     return await dbContext.Users.FindAsync(id);
    // }

    // public async Task<List<User>> GetAllUsersAsync()
    // {
    //     using var dbContext = DbContextFactory.Create();

    //     return await dbContext.Users.ToListAsync();
    // }

    // public async Task<User?> UpdateUserAsync(Guid id, string name, string? email)
    // {
    //     using var dbContext = DbContextFactory.Create();

    //     var user = await dbContext.Users.FindAsync(id);
    //     if (user == null)
    //     {
    //         return null;
    //     }

    //     user.Name = name;
    //     user.Email = email;

    //     await dbContext.SaveChangesAsync();

    //     return user;
    // }

    // public async Task<bool> DeleteUserAsync(Guid id)
    // {
    //     using var dbContext = DbContextFactory.Create();

    //     var user = await dbContext.Users.FindAsync(id);
    //     if (user == null)
    //     {
    //         return false;
    //     }

    //     dbContext.Users.Remove(user);
    //     await dbContext.SaveChangesAsync();

    //     return true;
    // }
}
