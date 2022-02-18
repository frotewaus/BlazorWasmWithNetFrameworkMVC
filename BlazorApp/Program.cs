using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp.Components;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
#if STANDALONE
            builder.RootComponents.Add<AppDebug>("#app");
#else
            builder.RootComponents.RegisterForJavaScript<Counter>(identifier: "counter", javaScriptInitializer: "loadCounter");
            builder.RootComponents.RegisterForJavaScript<Components.Index>(identifier: "index", javaScriptInitializer: "loadIndex");
            builder.RootComponents.RegisterForJavaScript<FetchData>(identifier: "fetchData", javaScriptInitializer: "loadFetchData");
#endif
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
