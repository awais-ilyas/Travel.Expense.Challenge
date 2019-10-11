using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;

namespace TravelExpenseChallenge.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;
        private DbSet<T> DbSet;
        string errorMessage = string.Empty;
        public Repository(AppDbContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public T Get(long id)
        {
            return DbSet.SingleOrDefault(s => s.Id == id);
        }
        public T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }
        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }
        public T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();
            var query = includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
            return query.FirstOrDefault(predicate);
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var record = DbSet.Add(entity).Entity;
            context.SaveChanges();
            return record;
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            DbSet.Remove(entity);
            context.SaveChanges();
        }
    }
}
