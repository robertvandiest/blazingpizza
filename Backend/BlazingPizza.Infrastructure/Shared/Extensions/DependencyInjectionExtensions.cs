using BlazingPizza.Domain.Shared;
using BlazingPizza.Infrastructure.Delivery.Extensions;
using BlazingPizza.Infrastructure.Kitchen.Extensions;
using BlazingPizza.Infrastructure.Ordering.Extensions;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlazingPizza.Infrastructure.Shared.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, params Assembly[] serviceAssemblies)
        {
            services
                .AddOrdering()
                .AddKitchen()
                .AddDelivery();

            services.AddMassTransit(x =>
            {
                x.AddConsumers(serviceAssemblies);

                // elided...
                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });

            });

            services.AddScoped<IEventFactory, EventFactory>();

            return services;
        }
    }
}
