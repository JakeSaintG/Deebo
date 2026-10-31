using System;
using System.Globalization;

namespace HomeManager.Server.Models;

public class LogConfiguration : ILogConfiguration
{
    public int RententionInDays { get; set; }
    public bool VerboseLogging { get; set; }
    public bool RetainAllErrors { get; set; }
    public bool RetainAllWarnings { get; set; }
    public bool ReplicateToThisNode { get; set; } 
    public int ReplicationBatchSize { get; set; }
    public int AckBatchSize { get; set; }
}
