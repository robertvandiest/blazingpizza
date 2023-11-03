using BlazingPizza.Domain.Ordering;
using BlazingPizza.Infrastructure.Ordering.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingPizza.Infrastructure.Ordering.Extensions
{
    internal static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddOrdering(this IServiceCollection services)
        {
            services.AddSqlite<OrderingContext>("Data Source=Ordering.db", d => d.MigrationsAssembly(typeof(DependencyInjectionExtensions).Assembly.FullName));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
