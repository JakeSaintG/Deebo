using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Server.Repositories;

public class UserService
{
    // Create a new user
    public async Task<User> CreateUserAsync(string name, string email)
    {
        using var dbContext = DbContextFactory.Create();

        var user = new User
        {
            Name = name,
            Email = email
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        return user;
    }

    // Get a user by ID
    public async Task<User?> GetUserByIdAsync(int id)
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.Users.FindAsync(id);
    }

    // Get all users
    public async Task<List<User>> GetAllUsersAsync()
    {
        using var dbContext = DbContextFactory.Create();

        return await dbContext.Users.ToListAsync();
    }

    // Update a user
    public async Task<User?> UpdateUserAsync(int id, string name, string email)
    {
        using var dbContext = DbContextFactory.Create();

        var user = await dbContext.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }

        user.Name = name;
        user.Email = email;

        await dbContext.SaveChangesAsync();

        return user;
    }

    // Delete a user
    public async Task<bool> DeleteUserAsync(int id)
    {
        using var dbContext = DbContextFactory.Create();

        var user = await dbContext.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();

        return true;
    }
}
