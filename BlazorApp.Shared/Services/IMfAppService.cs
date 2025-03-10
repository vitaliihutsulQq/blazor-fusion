namespace BlazorApp.Shared.Services
{
    public interface IMfAppService
    {
        void MapComponent<TComponent>(string route) where TComponent : class;
        Dictionary<string, Type> GetRoutes();
    }
}
