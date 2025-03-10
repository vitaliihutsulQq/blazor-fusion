using BlazorApp.Shared;
using BlazorApp.Shared.Services;
using BlazorApp.Shell;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



builder.Services.AddSharedModule(builder.Configuration);


builder.Services.AddSingleton<IMfAppService, MfAppService>();


var moduleTypes = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(a => a.GetTypes())
    .Where(t => typeof(IMfModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .ToList();

var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetName().Name).ToList();


if (!moduleTypes.Any())
{
    Console.WriteLine("[Shell] No modules found!");
}
else
{
    foreach (var moduleType in moduleTypes)
    {
        var module = (IMfModule)Activator.CreateInstance(moduleType);
        module.Configure(builder.Services);
    }
}

var host = builder.Build();
var appService = host.Services.GetRequiredService<IMfAppService>();

foreach (var moduleType in moduleTypes)
{
    var module = (IMfModule)Activator.CreateInstance(moduleType);
    await module.Setup(appService);

}


await host.RunAsync();
