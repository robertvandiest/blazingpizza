using BlazingPizza.Application.Ordering.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Application.Ordering.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddOrdering(this IServiceCollection services)
        {
            return services
                .AddScoped<OrderService>()
                .AddScoped<PizzaService>();
        }
    }
}
