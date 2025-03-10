namespace BlazorApp.Shared.Services
{
    public interface IModuleRegistry
    {
        Dictionary<string, string> GetModuleMappings();
    }
}
