namespace HomeManager.Server.Models;

public interface ILogEntry {
    public Guid Id { get; set; }
    public string LogLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string LogSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime LogDts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime LastModifiedDts { get; set; }
    public string? LogMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool Consumed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}