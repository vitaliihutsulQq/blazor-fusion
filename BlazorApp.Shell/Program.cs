using BlazorApp.Shared;
using BlazorApp.Shared.Services;
using BlazorApp.Shell;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSharedModule(builder.Configuration);
builder.Services.AddScoped<LazyAssemblyLoader>();
builder.Services.AddSingleton<IModuleRegistry, ModuleRegistry>();
builder.Services.AddSingleton<IMfAppService, MfAppService>();

var host = builder.Build();
await host.RunAsync();
