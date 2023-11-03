using BlazingPizza.Domain.Delivering.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Infrastructure.Delivering.EntityFramework
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = default!;

        public DbSet<Pizza> Pizzas { get; set; } = default!;

        public DbSet<Topping> Toppings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Delivering");

            modelBuilder
                .Entity<Pizza>()
                .HasMany(p => p.Toppings)
                .WithMany(t => t.Pizzas);
        }
    }
}
