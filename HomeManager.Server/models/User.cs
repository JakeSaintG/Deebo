using System;

namespace HomeManager.Server.Models;

public class User : IUserRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
}