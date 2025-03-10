using BlazorApp.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microfrontend.one
{
    public class Module : IMfModule
    {
        public void Configure(IServiceCollection services)
        {
            services.AddScoped<ModuleOne>();
        }

        public Task Setup(IMfAppService app)
        {
            Console.WriteLine("[Microfrontend.one] Registering route: /hello");
            app.MapComponent<ModuleOne>("/module-one");

            return Task.CompletedTask;
        }

        public Task Teardown(IMfAppService app)
        {
            return Task.CompletedTask;
        }
    }
}
