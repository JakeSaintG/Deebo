using System;

namespace HomeManager.Server.Models;

public class LogEntry: ILogEntry
{
    // TODO: add a monotonically increasing id
    // - "replication_id"
    // - will be used by replication nodes to "true up"

    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string LogLevel { get; set; }
    public required string LogSource { get; set; }
    
    // TODO: Maybe use a timestamp type?
    public required DateTime LogDts { get; set; }
    public string? LogMessage { get; set; }

    public bool Consumed { get; set; }
}