using Illegible_Cms_V2.Identity.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Identity.Api.Extensions.DependencyInjection;

public static class DatabaseInjection
{
    public static IServiceCollection AddConfiguredDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("IdentityDbConnection")).
           EnableSensitiveDataLogging().EnableDetailedErrors());
        }
        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("IdentityDbConnection")));
        return services;
    }
}
