using System;

namespace HomeManager.Server.Models;

public interface ILogConfiguration
{
    // retention in days
    // - Node specific
    // verboseLogging
    // retain errors
    // retrain warnings
    // replicate to this node?
    // - prevent log replication to this node
    // - still send logs to parent node
    // replication_batch_size
    // - ship log replication in batches of X until "trued up"
    // - until next interval
    // ack_batch_size
    // - The amount of log entries that the discord bot can pull
    // - until next interval
}