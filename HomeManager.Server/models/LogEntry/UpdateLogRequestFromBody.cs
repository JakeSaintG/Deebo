using System;

namespace HomeManager.Server.Models;

// TODO: This really only should be for acking
// Need to think of a log compression/retention but that shouldn't be an endpoint
public class UpdateLogRequestFromBody: ILogEntry
{
    public required Guid Id { get; set; }
    public required DateTime LastModifiedDts { get; set; }
    public bool Consumed { get; set; }
}