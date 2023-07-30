using System.Linq.Expressions;

namespace Bravi.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(params object?[]? keyValues);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        TEntity GetByID(params object?[]? keyValues);
        TEntity Insert(TEntity entity);
        void SaveChanges();
        void Update(TEntity entityToUpdate);
    }
}