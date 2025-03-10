using BlazorApp.Shared.Services;
using Microfrontend.two;
using Microsoft.Extensions.DependencyInjection;

namespace Microfrontend.one
{
    public class Module : IMfModule
    {
        public void Configure(IServiceCollection services)
        {
            services.AddScoped<ModuleTwo>();
        }

        public Task Setup(IMfAppService app)
        {
            app.MapComponent<ModuleTwo>("/module-two");

            return Task.CompletedTask;
        }

        public Task Teardown(IMfAppService app)
        {
            return Task.CompletedTask;
        }
    }
}
