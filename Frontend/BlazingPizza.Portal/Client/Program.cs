using BlazingPizza.API;
using BlazingPizza.Portal.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazingPizza.Portal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton(new BlazingPizzaApiClient(builder.HostEnvironment.BaseAddress, new HttpClient()));
            builder.Services.AddSingleton<PricingService>();
            builder.Services.AddScoped<OrderStateService>();

            await builder.Build().RunAsync();
        }
    }
}