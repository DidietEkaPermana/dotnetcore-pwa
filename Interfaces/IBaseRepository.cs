using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(object id);
        T Get(Expression<Func<T, bool>> where);
        // IEnumerable<T> GetAll();
        // IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0, int take = 0,
            string includeProperties = "");
        Task<int> GetTotalAsync(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0, int take = 0,
            string includeProperties = "");
        Task<IEnumerable<TResult>> SelectAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0, int take = 0,
            string includeProperties = "");
    }
}
