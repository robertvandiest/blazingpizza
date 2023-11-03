using BlazingPizza.Application.Shared.Extensions;
using BlazingPizza.Infrastructure;
using BlazingPizza.Infrastructure.Ordering.EntityFramework;
using BlazingPizza.Infrastructure.Shared.Extensions;

namespace BlazingPizza.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddApplication()
                .AddInfrastructure(Application.AssemblyRef.Reference);

            builder.Services.AddHttpClient();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var orderingContext = scope.ServiceProvider.GetRequiredService<OrderingContext>();

            SeedData.Create(orderingContext);

            app.Run();
        }
    }
}