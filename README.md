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
Each micromodule is a separate project that must:

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
**Step.2**
In the same module, create a component **ModuleOne.razor**:
```
@page "/module-one"
<h3>Hello, Microfrontend!</h3>

```
# 3. Add your micromodule in Blazor.Shell dependencies 
