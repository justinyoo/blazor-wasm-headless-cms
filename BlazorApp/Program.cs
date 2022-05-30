using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
{
    var baseUri = builder.HostEnvironment.IsDevelopment()
                  ? "http://localhost:7071/"
                  : builder.HostEnvironment.BaseAddress;
    return new HttpClient { BaseAddress = new Uri(baseUri) };
});

await builder.Build().RunAsync();