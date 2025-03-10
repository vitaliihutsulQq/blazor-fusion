using BlazorApp.Shared.Services;

namespace BlazorApp.Shared
{
    public class MfAppService : IMfAppService
    {
        private readonly Dictionary<string, Type> _routes = new();

        public void MapComponent<TComponent>(string route) where TComponent : class
        {
            if (!route.StartsWith("/")) route = "/" + route;
            _routes[route] = typeof(TComponent);
        }

        public Dictionary<string, Type> GetRoutes() => _routes;


    }
}
