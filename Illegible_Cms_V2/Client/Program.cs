using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();

builder.Services.AddMudBlazorDialog();
builder.Services.AddMudBlazorJsApi();
builder.Services.AddMudBlazorJsEvent();
builder.Services.AddMudBlazorKeyInterceptor();
builder.Services.AddMudBlazorResizeListener();
builder.Services.AddMudBlazorResizeObserver();
builder.Services.AddMudBlazorResizeObserverFactory();
builder.Services.AddMudBlazorScrollListener();
builder.Services.AddMudBlazorScrollManager();
builder.Services.AddMudBlazorScrollSpy();
builder.Services.AddMudBlazorSnackbar();
builder.Services.AddMudEventManager();
builder.Services.AddMudBlazorKeyInterceptor();


await builder.Build().RunAsync();