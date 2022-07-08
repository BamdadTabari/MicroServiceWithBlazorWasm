using Illegible_Cms_V2.Shared.BasicShared.Configurations;

namespace Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection
{
    public static class ConfigurationInjection
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisCacheConfig>(configuration.GetSection(RedisCacheConfig.Key));
            services.Configure<RabbitMQConfig>(configuration.GetSection(RabbitMQConfig.Key));

            return services;
        }
    }
}
