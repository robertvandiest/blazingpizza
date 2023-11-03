using BlazingPizza.Domain.Ordering;
using BlazingPizza.Domain.Ordering.Entities;
using BlazingPizza.Domain.Shared;
using BlazingPizza.Infrastructure.Ordering.EntityFramework;
using BlazingPizza.Infrastructure.Ordering.Repositories;

namespace BlazingPizza.Infrastructure.Ordering
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly OrderingContext _orderingContext;

        public UnitOfWork(OrderingContext orderingContext)
        {
            _orderingContext = orderingContext;
        }

        public IRepository<PizzaSpecial> Specials => new PizzaSpecialRepository(_orderingContext);

        public IRepository<Order> Orders => new OrderRepository(_orderingContext);

        public async Task SaveChangesAsync()
        {
            await _orderingContext.SaveChangesAsync();
        }
    }
}
