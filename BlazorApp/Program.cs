using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorApp;
using BlazorApp.Proxies;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp =>
{
    var httpClient = sp.GetService<HttpClient>();
    if (builder.HostEnvironment.IsDevelopment() != true)
    {
        httpClient.BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress.TrimEnd('/')}/api");
    }
    return new ProxyClient(httpClient);
});

await builder.Build().RunAsync();