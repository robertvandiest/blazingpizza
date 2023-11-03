using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Application.Kitchen.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddKitchen(this IServiceCollection services)
        {
            return services;
        }
    }
}
