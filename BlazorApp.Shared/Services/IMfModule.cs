using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp.Shared.Services
{
    public interface IMfModule
    {
        void Configure(IServiceCollection services); // Registering module services
        Task Setup(IMfAppService app); // Setting up the module
        Task Teardown(IMfAppService app); // Clearing data when deleting
    }
}
