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
    var http = sp.GetService<HttpClient>();
    var proxy = new ProxyClient(http);
    if (builder.HostEnvironment.IsDevelopment() != true)
    {
        proxy.BaseUrl = $"{builder.HostEnvironment.BaseAddress.TrimEnd('/')}/api";
    }

    return proxy;
});

await builder.Build().RunAsync();