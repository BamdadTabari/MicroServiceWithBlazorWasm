namespace Illegible_Cms_V2.Server.Api.Extensions.Middleware;

internal static class ConfiguredSwaggerMiddleware
{
    public static void UseConfiguredSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(configs =>
            configs.SwaggerEndpoint("/swagger/v1/swagger.json", "Server API v1"));
    }
}