using BlazorApp.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.Shared
{
    public static class SharedModule
    {
        public static IServiceCollection AddSharedModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISharedService, SharedService>();
            services.AddSingleton<IMfAppService, MfAppService>();
            services.AddSingleton(configuration);
            return services;
        }
    }
}
