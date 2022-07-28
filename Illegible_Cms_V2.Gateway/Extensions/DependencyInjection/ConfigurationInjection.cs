using Illegible_Cms_V2.Gateway.Configurations;
using Illegible_Cms_V2.Gateway.Helpers;
using Illegible_Cms_V2.Shared.BasicShared.Configurations;

namespace Illegible_Cms_V2.Gateway.Extensions.DependencyInjection;

public static class ConfigurationInjection
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        // Jwt helper static config
        JwtHelper.Config = configuration.GetSection(SecurityTokenConfig.Key).Get<SecurityTokenConfig>();

        services.Configure<RedisCacheConfig>(configuration.GetSection(RedisCacheConfig.Key));
        services.Configure<RabbitMQConfig>(configuration.GetSection(RabbitMQConfig.Key));

        return services;
    }
}