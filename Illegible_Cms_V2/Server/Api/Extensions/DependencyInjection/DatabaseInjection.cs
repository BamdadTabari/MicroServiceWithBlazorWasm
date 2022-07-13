using Illegible_Cms_V2.Server.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection
{
    public static class DatabaseInjection
    {
        public static IServiceCollection AddConfiguredDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ServerDbConnection")));

            return services;
        }
    }
}