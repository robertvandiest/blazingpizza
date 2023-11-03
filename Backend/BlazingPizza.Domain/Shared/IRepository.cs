using System.Linq.Expressions;

namespace BlazingPizza.Domain.Shared
{
    public interface IRepository<TEntity>
    {
        public void CreateOne(TEntity entity);

        public IReadOnlyCollection<TProjected> FindAll<TProjected>(
            Expression<Func<TEntity, bool>>? predicate = null,
            Expression<Func<TEntity, TProjected>>? projection = null);

        public TProjected? FindOne<TProjected>(
            Expression<Func<TEntity, bool>>? predicate = null,
            Expression<Func<TEntity, TProjected>>? projection = null);
    }
}
