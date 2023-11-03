using BlazingPizza.Domain.Delivering.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Domain.Shared.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services.AddDelivering();
        }
    }
}
