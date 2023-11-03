using BlazingPizza.Domain.Ordering.Entities;
using BlazingPizza.Infrastructure.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BlazingPizza.Infrastructure.Ordering.EntityFramework
{
    public class OrderingContext : DbContext
    {
        public OrderingContext(DbContextOptions<OrderingContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = default!;

        public DbSet<Pizza> Pizzas { get; set; } = default!;

        public DbSet<PizzaSpecial> Specials { get; set; } = default!;

        public DbSet<Topping> Toppings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Ordering");

            modelBuilder
                .Entity<Pizza>()
                .HasMany(p => p.Toppings)
                .WithMany(t => t.Pizzas);
        }
    }
}
