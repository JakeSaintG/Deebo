using HomeManager.Server.Context;
using HomeManager.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeManager.Server.Repositories;

public class BotConfigurationService
{
    public async Task<BotConfiguration> CreateBotConfigAsync(
        string BotName,
        string BotKey,
        bool BotActive,
        int? LogPullIntervalInMinutes,
        int? LogPullBatchSize
    )
    {
        using var dbContext = DbContextFactory.Create();

        int pullIntervalInMinutes = (int)((LogPullIntervalInMinutes != null) ? LogPullIntervalInMinutes : 5);
        int pullBatchSize = (int)((LogPullBatchSize != null) ? LogPullBatchSize : 100);

        var config = new BotConfiguration
        {
            BotId = Guid.NewGuid(),
            BotName = BotName,
            BotKey = BotKey,
            BotActive = BotActive,
            LogPullIntervalInMinutes = pullIntervalInMinutes,
            LogPullBatchSize = pullBatchSize,
        };

        dbContext.BotConfiguration.Add(config);
        await dbContext.SaveChangesAsync();

        return config;
    }

    public async Task<BotConfiguration?> GetBotConfigByIdAsync(Guid id)
    {
        using var dbContext = DbContextFactory.Create();

        BotConfiguration? result = await dbContext.BotConfiguration.FindAsync(id);
        result?.BotKey = "REDACTED";
        return result;
    }

    public async Task<BotConfiguration?> UpdateBotConfigAsync(
        Guid id,
        string BotName,
        string BotKey,
        bool BotActive, 
        int? LogPullIntervalInMinutes, 
        int? LogPullBatchSize
    )
    {
        using var dbContext = DbContextFactory.Create();

        var config = await dbContext.BotConfiguration.FindAsync(id);
        if (config == null)
        {
            return null;
        }

        config.LastModifiedDts = new DateTime();
        config.BotKey = BotKey;
        config.BotActive = BotActive;
        config.BotName = BotName;
        if (LogPullIntervalInMinutes != null) config.LogPullIntervalInMinutes = (int)LogPullIntervalInMinutes;
        if (LogPullBatchSize != null) config.LogPullBatchSize = (int)LogPullBatchSize;

        await dbContext.SaveChangesAsync();

        return config;
    }

    public async Task<bool> DeleteBotConfigAsync(Guid id)
    {
        using var dbContext = DbContextFactory.Create();

        var config = await dbContext.BotConfiguration.FindAsync(id);
        if (config == null)
        {
            return false;
        }

        dbContext.BotConfiguration.Remove(config);
        await dbContext.SaveChangesAsync();

        return true;
    }
}
