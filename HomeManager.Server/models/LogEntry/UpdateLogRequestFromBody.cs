using System;

namespace HomeManager.Server.Models;

// TODO: This really only should be for acking
// Need to think of a log compression/retention but that shouldn't be an endpoint
public class UpdateLogRequestFromBody: ILogEntry
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string LogLevel { get; set; }
    public required string LogSource { get; set; }
    
    // TODO: Maybe use a timestamp type?
    public required string LogDTS { get; set; }
    public string? LogMessage { get; set; }

    public bool Consumed { get; set; }
}