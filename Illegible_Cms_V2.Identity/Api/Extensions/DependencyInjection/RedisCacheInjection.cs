using Illegible_Cms_V2.Shared.BasicShared.Configurations;

namespace Illegible_Cms_V2.Identity.Api.Extensions.DependencyInjection
{
    public static class RedisCacheInjection
    {
        public static IServiceCollection AddConfiguredRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(RedisCacheConfig.Key).Get<RedisCacheConfig>();

            // Distributed caching
            //services.AddStackExchangeRedis("identity", config);

            return services;
        }
    }
}
