// TODO:
// mode `public string? DiscordKey  {get; set;}` from nodeconfig to here
// Should also build ability to turn bot off
// - "bring your own bot"
// various interval configuration
// - interval to pull logs
// limit/amaount of logs to pull at once

public interface IBotConfiguration
{
    public string BotKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool BotActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int LogPullIntervalInMinutes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int LogPullBatchSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
