using BlazingPizza.Domain.Kitchen;
using BlazingPizza.Infrastructure.Kitchen.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Infrastructure.Kitchen.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddKitchen(this IServiceCollection services)
        {
            services.AddSqlite<KitchenContext>("Data Source=Kitchen.db", d => d.MigrationsAssembly(typeof(DependencyInjectionExtensions).Assembly.FullName));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
