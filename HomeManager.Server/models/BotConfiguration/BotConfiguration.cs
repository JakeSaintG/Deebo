// TODO:
// mode `public string? DiscordKey  {get; set;}` from nodeconfig to here
// Should also build ability to turn bot off
// - "bring your own bot"
// various interval configuration
// - interval to pull logs
// limit/amaount of logs to pull at once

public class BotConfiguration: IBotConfiguration
{
    public required Guid BotId {get; set;}
    public required string BotKey {get; set;}
    public required bool BotActive {get; set;}
    public int LogPullIntervalInMinutes {get; set;}
    public int LogPullBatchSize {get; set;}
}
