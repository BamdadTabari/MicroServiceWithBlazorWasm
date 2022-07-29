using Illegible_Cms_V2.Shared.BasicShared.HealthChecks;

namespace Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection;

public static class HealthCheckInjection
{
    public static IServiceCollection AddConfiguredHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<GeneralHealthCheck>("general-check");

        return services;
    }
}