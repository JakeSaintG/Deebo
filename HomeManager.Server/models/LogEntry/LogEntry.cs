using System;

namespace HomeManager.Server.Models;

public class LogEntry: ILogEntry
{
    public required Guid Id { get; set; }
    public required string LogLevel { get; set; }
    public required string LogSource { get; set; }
    public required DateTime LogDts { get; set; }
    public required DateTime LastModifiedDts { get; set; }
    public int? ReplicationId { get; set; }
    public string? LogMessage { get; set; }
    public bool Consumed { get; set; }
}