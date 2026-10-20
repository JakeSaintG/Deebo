namespace HomeManager.Server.Models;

public interface ILogEntry {
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string LogLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string LogSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
    // TODO: Maybe use a timestamp type?
    public string LogDTS { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? LogMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool Consumed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}