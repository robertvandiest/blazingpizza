using BlazingPizza.Domain.Kitchen.Entities;
using BlazingPizza.Infrastructure.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Infrastructure.Kitchen.EntityFramework
{
    public class KitchenContext : DbContext
    {
        public KitchenContext(DbContextOptions<KitchenContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = default!;

        public DbSet<Pizza> Pizzas { get; set; } = default!;

        public DbSet<Topping> Toppings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Kitchen");

            modelBuilder
                .Entity<Pizza>()
                .HasMany(p => p.Toppings)
                .WithMany(t => t.Pizzas);
        }
    }
}
