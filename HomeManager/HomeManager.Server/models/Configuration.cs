using System;

namespace HomeManager.Server.Models;

public class Configuration
{
    public required Guid Id { get; set; }
    public required string SelfIp  {get; set;}
    public required string LeaderIp  {get; set;}
    public bool DesignatedLeader  {get; set;}
    public bool IsLeader  {get; set;}
    public string[] Roles  {get; set;}
    public bool RolesBlocked  {get; set;}
    public string[] NodesIps  {get; set;}
    public bool LeaderCandidate  {get; set;}
    public string DiscordKey  {get; set;}

}