using Illegible_Cms_V2.Shared.BasicShared.Configurations;
using Illegible_Cms_V2.Shared.SharedServices.Caching;
using Illegible_Cms_V2.Shared.SharedServices.Caching.StackExchangeRedis;

using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Illegible_Cms_V2.Shared.BasicShared.DependencyInjection;

public static class StackExchangeRedisInjection
{
    public static IServiceCollection AddStackExchangeRedis(this IServiceCollection services,
        string instancePrefix, RedisCacheConfig config)
    {
        var options = new ConfigurationOptions();
        foreach (var connection in config.Connections)
            options.EndPoints.Add(connection);

        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(options));

        services.AddScoped<ICache>(x =>
            new StackExchangeRedisCache(x.GetRequiredService<IConnectionMultiplexer>(),
                instancePrefix: instancePrefix));

        return services;
    }
}