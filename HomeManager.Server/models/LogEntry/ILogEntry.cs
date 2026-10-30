namespace HomeManager.Server.Models;

public interface ILogEntry {
    // TODO: add a monotonically increasing id
    // - "replication_id"
    // - will be used by replication nodes to "true up"
    
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string LogLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string LogSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    // TODO: Maybe use a timestamp type?
    public DateTime LogDts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? LogMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool Consumed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}