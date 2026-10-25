using System;

namespace HomeManager.Server.Models;

public interface IConfiguration {
    public bool IsLeader { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string[]? Roles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool RolesBlocked { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string[]? NodesIps { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool LeaderCandidate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime? LeaderSinceDTS { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? DiscordKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}