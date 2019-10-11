using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TravelExpenseChallenge.Models;

namespace TravelExpenseChallenge.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        T Get(long id);
        T Find(params object[] keys);
        T Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
