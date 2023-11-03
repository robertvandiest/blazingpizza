using BlazingPizza.Application.Kitchen.Extensions;
using BlazingPizza.Application.Ordering.Extensions;
using BlazingPizza.Domain.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Application.Shared.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddOrdering();
            services.AddKitchen();
            services.AddDomain();

            return services;
        }
    }
}
