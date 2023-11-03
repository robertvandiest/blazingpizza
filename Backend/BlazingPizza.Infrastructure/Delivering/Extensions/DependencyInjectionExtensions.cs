using BlazingPizza.Domain.Delivering;
using BlazingPizza.Infrastructure.Delivering;
using BlazingPizza.Infrastructure.Delivering.EntityFramework;
using BlazingPizza.Infrastructure.Kitchen.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Infrastructure.Delivery.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDelivery(this IServiceCollection services)
        {
            services.AddSqlite<DeliveryContext>("Data Source=Delivery.db", d => d.MigrationsAssembly(typeof(DependencyInjectionExtensions).Assembly.FullName));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
