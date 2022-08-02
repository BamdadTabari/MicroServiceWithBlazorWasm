    using Illegible_Cms_V2.Server.Api.Extensions.DependencyInjection;
using Illegible_Cms_V2.Server.Api.Extensions.Middleware;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

builder.Configuration.AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

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
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
    // register an HttpClient that points to itself
    builder.Services.AddSingleton(sp =>
    {
        // Get the address that the app is currently running at
        var server = sp.GetRequiredService<IServer>();
        var addressFeature = server.Features.Get<IServerAddressesFeature>();
        var baseAddress = addressFeature.Addresses.First();
        return new HttpClient { BaseAddress = new Uri(baseAddress) };
    });

    //// Add services to the container.
    builder.Services.AddConfigurations(configuration);
    builder.Services.AddConfiguredDatabase(configuration);
    builder.Services.AddServices();
    builder.Services.AddConfiguredMediatR();

    builder.Services.AddConfiguredMassTransit(configuration);
    builder.Services.AddConfiguredHealthChecks();
    builder.Services.AddMvc();
    #endregion

    var app = builder.Build();

    #region app


    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseDeveloperExceptionPage();
    app.UseConfiguredExceptionHandler(environment);

    Log.Information($"Starting {appName}[{env}] on {address}");

    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.MapRazorPages();
    app.MapControllers();
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHealthChecks("/health");
        endpoints.MapRazorPages(); // <- Add this (for prerendering)
        endpoints.MapFallbackToPage("/_Host"); // <- Change method + file (for prerendering)
    });
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