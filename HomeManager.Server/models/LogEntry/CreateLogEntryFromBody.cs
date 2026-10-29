using System;

namespace HomeManager.Server.Models;

public class CreateLogEntryFromBody: ILogEntry
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
    public required string LogLevel { get; set; }
    public required string LogSource { get; set; }
    
    // TODO: Maybe use a timestamp type?
    public required string LogDTS { get; set; }
    public string? LogMessage { get; set; }
}