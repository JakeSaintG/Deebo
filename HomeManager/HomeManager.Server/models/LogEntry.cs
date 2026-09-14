using System;

namespace HomeManager.Server.Models;

public class LogEntry
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string LogLevel { get; set; }
    public required string LogSource { get; set; }
    
    //Maybe use a timestamp type?
    public required string LogDTS { get; set; }
    public string? LogMessage { get; set; }

    public bool Consumed { get; set; }
}