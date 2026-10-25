using System;
using System.Data;

namespace HomeManager.Server.Models;

public class Configuration : IConfiguration
{
    public required Guid Id { get; set; }
    public required string SelfIp  {get; set;}
    public required string LeaderIp  {get; set;}
    public bool IsLeader  {get; set;}
    public string[]? Roles  {get; set;}
    public bool RolesBlocked  {get; set;}
    public string[]? NodesIps  {get; set;}
    
    //Determine if a node can pick up leader responsibilities if the current one goes down
    public bool LeaderCandidate  {get; set;}
    public DateTime? LeaderSinceDTS  {get; set;}
    public string? DiscordKey  {get; set;}
}