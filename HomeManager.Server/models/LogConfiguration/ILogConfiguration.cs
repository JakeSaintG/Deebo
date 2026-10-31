using System;

namespace HomeManager.Server.Models;

public interface ILogConfiguration
{
    public int RententionInDays { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool VerboseLogging { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool RetainAllErrors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool RetainAllWarnings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool ReplicateToThisNode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int ReplicationBatchSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int AckBatchSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
