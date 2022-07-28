using Illegible_Cms_V2.Shared.BasicShared.Configurations;
using Illegible_Cms_V2.Shared.BasicShared.DependencyInjection;

namespace Illegible_Cms_V2.Gateway.Extensions.DependencyInjection;

public static class RedisCacheInjection
{
    public static IServiceCollection AddConfiguredRedisCache(this IServiceCollection services,
        IConfiguration configuration)
    {
        var config = configuration.GetSection(RedisCacheConfig.Key).Get<RedisCacheConfig>();

        // Distributed caching
        services.AddStackExchangeRedis("gateway", config);

        return services;
    }
}