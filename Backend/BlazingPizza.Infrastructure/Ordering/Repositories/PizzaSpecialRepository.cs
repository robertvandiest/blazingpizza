using BlazingPizza.Domain.Ordering.Entities;
using BlazingPizza.Domain.Shared;
using BlazingPizza.Infrastructure.Ordering.EntityFramework;
using BlazingPizza.Infrastructure.Shared;
using System.Linq.Expressions;

namespace BlazingPizza.Infrastructure.Ordering.Repositories
{
    internal class PizzaSpecialRepository : RepositoryBase<PizzaSpecial>, IRepository<PizzaSpecial>
    {
        private readonly OrderingContext _context;

        public PizzaSpecialRepository(OrderingContext context)
        {
            _context = context;
        }

        public void CreateOne(PizzaSpecial entity)
        {
            _context.Specials.Add(entity);
        }

        public IReadOnlyCollection<TProjected> FindAll<TProjected>(
            Expression<Func<PizzaSpecial, bool>>? predicate = null, 
            Expression<Func<PizzaSpecial, TProjected>>? projection = null)
        {
            return ApplyProjector(_context.Specials, predicate, projection).ToList().AsReadOnly();
        }

        public TProjected? FindOne<TProjected>(
            Expression<Func<PizzaSpecial, bool>>? predicate = null, 
            Expression<Func<PizzaSpecial, TProjected>>? projection = null)
        {
            return ApplyProjector(_context.Specials, predicate, projection).FirstOrDefault();
        }
    }
}
