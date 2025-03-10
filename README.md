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
