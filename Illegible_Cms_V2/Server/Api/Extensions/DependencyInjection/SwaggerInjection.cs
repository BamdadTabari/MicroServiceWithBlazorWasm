using Microsoft.OpenApi.Models;

namespace Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection
{
    public static class SwaggerInjection
    {
        public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(configs =>
                configs.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "Server Service Api",
                        Version = "v1"
                    }));

            return services;
        }
    }
}
