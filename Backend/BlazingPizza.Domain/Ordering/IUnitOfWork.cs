using BlazingPizza.Domain.Ordering.Entities;
using BlazingPizza.Domain.Shared;

namespace BlazingPizza.Domain.Ordering
{
    public interface IUnitOfWork
    {
        public IRepository<PizzaSpecial> Specials { get; }

        public IRepository<Order> Orders { get; }

        public Task SaveChangesAsync();
    }
}
