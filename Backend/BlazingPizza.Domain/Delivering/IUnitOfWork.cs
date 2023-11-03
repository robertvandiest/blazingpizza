using BlazingPizza.Domain.Delivering.Entities;
using BlazingPizza.Domain.Shared;

namespace BlazingPizza.Domain.Delivering
{
    public interface IUnitOfWork
    {
        IRepository<Order> Orders { get; }

        Task SaveChangesAsync();
    }
}
