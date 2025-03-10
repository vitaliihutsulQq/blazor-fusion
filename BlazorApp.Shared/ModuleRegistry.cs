using BlazorApp.Shared.Services;

namespace BlazorApp.Shared
{
    public class ModuleRegistry : IModuleRegistry
    {
        private readonly Dictionary<string, string> moduleMappings = new();

        public ModuleRegistry()
        {
            moduleMappings.Add("module-one", "Microfrontend.one.wasm");
            moduleMappings.Add("module-two", "Microfrontend.two.wasm");
        }

        public Dictionary<string, string> GetModuleMappings()
        {
            return moduleMappings;
        }
    }
}
