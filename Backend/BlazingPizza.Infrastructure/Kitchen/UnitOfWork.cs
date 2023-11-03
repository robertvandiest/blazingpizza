using BlazingPizza.Domain.Kitchen;
using BlazingPizza.Domain.Kitchen.Entities;
using BlazingPizza.Domain.Shared;
using BlazingPizza.Infrastructure.Kitchen.EntityFramework;
using BlazingPizza.Infrastructure.Kitchen.Repositories;

namespace BlazingPizza.Infrastructure.Kitchen
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KitchenContext _context;

        public UnitOfWork(KitchenContext context)
        {
            _context = context;
        }

        public IRepository<Order> Orders => new OrderRepository(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
