using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Domain.Delivering.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDelivering(this IServiceCollection services)
        {
            return services;
        }
    }
}
