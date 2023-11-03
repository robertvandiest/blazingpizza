using System.Linq.Expressions;

namespace BlazingPizza.Infrastructure.Shared
{
    internal abstract class RepositoryBase<TEntity>
    {
        protected RepositoryBase() { }

        protected IQueryable<TProjected> ApplyProjector<TProjected>(
            IQueryable<TEntity> queryable, 
            Expression<Func<TEntity, bool>>? predicate = null, 
            Expression<Func<TEntity, TProjected>>? projection = null)
        {
            var query = predicate is null ? queryable : queryable.Where(predicate);

            if (projection is null) return (IQueryable<TProjected>)query;

            return query.Select(projection);
        }
    }
}
