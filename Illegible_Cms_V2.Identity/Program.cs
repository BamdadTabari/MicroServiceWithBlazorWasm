using Illegible_Cms_V2.Identity.Api.Extensions.DependencyInjection;
using Illegible_Cms_V2.Identity.Api.Extensions.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Environment and System Name
string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

// Configuration
builder.Configuration.AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json")
            .AddEnvironmentVariables();

// Logger
Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

builder.Host.UseSerilog().
    ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

try
{
    Log.Information("Configuring web host ({ApplicationContext})...", appName);

    ConfigurationManager configuration = builder.Configuration;
    IWebHostEnvironment environment = builder.Environment;
    string address = configuration.GetValue<string>("urls");

    #region builder

    // Add services to the container.
    builder.Services.AddConfigurations(configuration);
    builder.Services.AddConfiguredDatabase(configuration);
    builder.Services.AddServices();
    builder.Services.AddConfiguredMediatR();

    builder.Services.AddConfiguredMassTransit(configuration);
    builder.Services.AddConfiguredHealthChecks();
    builder.Services.AddConfiguredSwagger();
    builder.Services.AddControllers();

    #endregion

    var app = builder.Build();

    #region app

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseDeveloperExceptionPage();
    app.UseConfiguredExceptionHandler(environment);
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHealthChecks("/health");
        endpoints.MapControllers();
    });

    if (!environment.IsProduction())
        app.UseConfiguredSwagger();

    Log.Information($"Starting {appName}[{env}] on {address}");

    app.Run();

    #endregion

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