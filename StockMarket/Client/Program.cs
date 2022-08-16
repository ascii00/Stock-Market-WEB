using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Syncfusion.Blazor;

namespace StockMarket.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjU3MzIxQDMyMzAyZTMxMmUzME1VbzBQcEFZQXJnZU9iRVJJOG02aXRmNmhsdHZ6NmE1alEvTjFrQVF5TTA9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("StockMarket.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            builder.Services.AddSyncfusionBlazor();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("StockMarket.ServerAPI"));

            builder.Services.AddApiAuthorization();
            
            builder.Services.AddApiAuthorization(options => {
                options.AuthenticationPaths.LogOutSucceededPath = "authentication/login";
            });

            await builder.Build().RunAsync();
        }
    }
}
