using Bravi.Data.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bravi.Data
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        public DbSet<TEntity> dbSet;
        public Repository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        
        public virtual IEnumerable<TEntity> Get<TProperty>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, TProperty>> navigationPropertyPath = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if(navigationPropertyPath != null)
            {
                query = query.Include(navigationPropertyPath);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(params object?[]? keyValues)
        {
            return dbSet.Find(keyValues);
        }
        public virtual TEntity Insert(TEntity entity)
        {
            return dbSet.Add(entity).Entity;
        }
        public virtual void Delete(params object?[]? keyValues)
        {
            TEntity entityToDelete = dbSet.Find(keyValues);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
    }

}
