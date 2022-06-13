using Illegible_Cms_V2.Identity.Application.Configurations;
using Illegible_Cms_V2.Identity.Application.Helpers;
using Illegible_Cms_V2.Shared.BasicShared.Configurations;

namespace Illegible_Cms_V2.Identity.Api.Extensions.DependencyInjection
{
    public static class ConfigurationInjection
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            // Jwt helper static config
            JwtHelper.Config = configuration.GetSection(SecurityTokenConfig.Key).Get<SecurityTokenConfig>();

            // User helper static lockout config
         //   UserHelper.LockoutConfig = configuration.GetSection(LockoutConfig.Key).Get<LockoutConfig>();

            services.Configure<RedisCacheConfig>(configuration.GetSection(RedisCacheConfig.Key));
            services.Configure<RabbitMQConfig>(configuration.GetSection(RabbitMQConfig.Key));

            return services;
        }
    }
}
