namespace Illegible_Cms_V2.Gateway.Extensions.DependencyInjection;

public static class CorsInjection
{
    public static IServiceCollection AddConfiguredCors(this IServiceCollection services, string policyName,
        IConfiguration configuration)
    {
        var origins = configuration.GetSection("AllowedOrigins").Get<string[]>();

        services.AddCors(options =>
        {
            options.AddPolicy(policyName, builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(origins)
                .AllowCredentials());
        });

        return services;
    }
}