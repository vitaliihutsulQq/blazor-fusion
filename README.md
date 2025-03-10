Blazor Microfrontend Platform is a modular microfrontend app built on Blazor WebAssembly.
It allows you to dynamically load and manage independent modules, improving scalability, maintainability, and development.

 * Dynamic module loading – modules can be added or updated without rebuilding the entire app.
 * Lazy-loading of components – only the necessary parts of the interface are loaded.
 * Isolated development – ​​each microfrontend can be developed and tested independently.
 * Flexibility – easily integrate new modules without changing the core.

BlazorMicrofrontends\
 ── BlazorApp.Shell/ # Main Shell (main application)\
 ── Microfrontend.one/ # First Microfrontend module\
 ── Microfrontend.two/ # Second Microfrontend module\
 ── BlazorApp.Shared/ # Shared components and services\

# 1. Creating a new micromodule:
Each micromodule is a separate Blazor Class Library that must:

Implement the **IMfModule** interface
Register routes and components
Be loaded into **Blazor.Shell**

# 2.Adding a new module
Each module should have its own **Module.cs** and register routes.

**Step.1**
Inside the module project (for example, Microfrontend.one), create a **Module.cs** file:
```
public class Module : IMfModule
    {
        public void Configure(IServiceCollection services)
        {
            // Register component in DI
            services.AddScoped<ModuleOne>();
        }

        public Task Setup(IMfAppService app)
        {
            // Register route
            app.MapComponent<ModuleOne>("/module-one");

            return Task.CompletedTask;
        }
    }
```
In the same module, create a component **ModuleOne.razor**:

```
@page "/module-one"
<h3>Hello, Microfrontend!</h3>
```
**Step.2**
To avoid specifying each module manually, use **ModuleRegistry**

```
public class ModuleRegistry : IModuleRegistry
{
    private readonly Dictionary<string, string> moduleMappings = new();

    public ModuleRegistry()
    {
        // Adding new modules
        moduleMappings.Add("module-one", "Microfrontend.one");
        moduleMappings.Add("module-two", "Microfrontend.two");
        moduleMappings.Add("module-three", "Microfrontend.three");
        moduleMappings.Add("module-four", "Microfrontend.four"); 
    }

    public Dictionary<string, string> GetModuleMappings()
    {
        return moduleMappings;
    }
}
```
**Step.3**
Add your modules .dll or wasm (see [.NET 8 blazor .wasm Lazy Loaded Assemblies throws runtime exception and fails to load](https://github.com/dotnet/runtime/issues/95381)) to lazy loading in Blazor.Shell.csproj:

```
<ItemGroup>
    <BlazorWebAssemblyLazyLoad Include="Microfrontend.one.wasm" />
    <BlazorWebAssemblyLazyLoad Include="Microfrontend.two.wasm" />
    <BlazorWebAssemblyLazyLoad Include="Microfrontend.three.wasm" />
    <BlazorWebAssemblyLazyLoad Include="Microfrontend.four.wasm" /> 
</ItemGroup>

<ItemGroup>
    <ProjectReference Include="..\Microfrontend.one\Microfrontend.one.csproj" />
    <ProjectReference Include="..\Microfrontend.two\Microfrontend.two.csproj" />
    <ProjectReference Include="..\Microfrontend.three\Microfrontend.three.csproj" />
    <ProjectReference Include="..\Microfrontend.four\Microfrontend.four.csproj" /> 
</ItemGroup>
```

