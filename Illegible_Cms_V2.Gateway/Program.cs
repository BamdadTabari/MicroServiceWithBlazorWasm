using Illegible_Cms_V2.Gateway.Extensions.DependencyInjection;
using Illegible_Cms_V2.Gateway.Extensions.Middleware;
using Illegible_Cms_V2.Gateway.Infrastructure;
using Ocelot.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Environment and System Name
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var appName = Assembly.GetExecutingAssembly().GetName().Name;

// Configuration
builder.Configuration.AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json")
    .AddJsonFile("ocelot.json", false, true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddRazorPages();
// Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog().ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders());

try
{
    Log.Information("Configuring web host ({ApplicationContext})...", appName);

    var configuration = builder.Configuration;
    var environment = builder.Environment;
    configuration.AddOcelot("RoutingConfigurations", environment);

    var address = configuration.GetValue<string>("urls");

    // Add services to the container.
    builder.Services.AddConfigurations(configuration);
    builder.Services.AddConfiguredCors("general-policy", configuration);
    builder.Services.AddConfiguredMassTransit(configuration);
    builder.Services.AddConfiguredAuthentication(configuration);
    builder.Services.AddConfiguredHealthChecks();
    builder.Services.AddOcelot(configuration);

    var app = builder.Build();

    app.UseHsts();
    app.UseHttpsRedirection();
    
    app.UseStaticFiles();
    app.UseRouting();
    app.MapRazorPages();
    app.UseDeveloperExceptionPage();
    app.UseCors("general-policy");
    app.UseConfiguredExceptionHandler(environment);
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHealthChecks("/health");
        endpoints.MapControllers();
    });

    app.UseOcelot(new OcelotPipelineConfiguration
    {
        PreAuthorizationMiddleware = async (ctx, next) =>
        {
            await AuthorizationHelper.AddPermissionClaimsAsync(ctx);
            await next.Invoke();
        },
        AuthenticationMiddleware = async (ctx, next) =>
        {
            // Check requirement of authentication
            var AuthenticationProviderKey = ((DownstreamRoute)ctx.Items["DownstreamRoute"]).AuthenticationOptions
                .AuthenticationProviderKey;

            if (!string.IsNullOrEmpty(AuthenticationProviderKey))
                await ConfiguredAuthenticationMiddleware.UseConfiguredAuthentication(ctx, next);
            else
                await next.Invoke();
        }
    });

    Log.Information($"Starting {appName}[{env}] on {address}");

    app.Run();

    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", appName);
    return 1;
}
finally
{
    Log.CloseAndFlush();
}