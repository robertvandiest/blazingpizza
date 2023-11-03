using BlazingPizza.Domain.Kitchen.Entities;
using BlazingPizza.Domain.Shared;

namespace BlazingPizza.Domain.Kitchen
{
    public interface IUnitOfWork
    {
        IRepository<Order> Orders { get; }

        Task SaveChangesAsync();
    }
}
