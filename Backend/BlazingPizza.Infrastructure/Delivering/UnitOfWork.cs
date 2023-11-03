using BlazingPizza.Domain.Delivering;
using BlazingPizza.Domain.Delivering.Entities;
using BlazingPizza.Domain.Shared;
using BlazingPizza.Infrastructure.Delivering.EntityFramework;
using BlazingPizza.Infrastructure.Delivering.Repositories;

namespace BlazingPizza.Infrastructure.Delivering
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryContext _context;

        public UnitOfWork(DeliveryContext context)
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
