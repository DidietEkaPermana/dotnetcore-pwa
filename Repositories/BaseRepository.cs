using AppCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppCore.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        private DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public DbContext Context
        {
            get { return dbContext; }
        }

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Edit(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }
        #region get
        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0, int take = 0,
            string includeProperties = "")
        {
            IQueryable<T> query = GetData(filter, orderBy, skip, take, includeProperties);

            return query.AsEnumerable().ToList();
        }
        public virtual async Task<int> GetTotalAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = GetData(filter, null, 0, 0, "");

            return await query.CountAsync();
        }
        // public IEnumerable<T> GetAll()
        // {
        //     return dbSet.ToList();
        // }

        // public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        // {
        //     return dbSet.Where(where).ToList();
        // }
        public virtual async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0, int take = 0,
            string includeProperties = "")
        {
            IQueryable<T> query = GetData(filter, orderBy, skip, take, includeProperties);

            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int skip = 0, int take = 0,
            string includeProperties = "")
        {
            IQueryable<T> query = GetData(filter, orderBy, skip, take, includeProperties);

            return await query.Select(selector).ToListAsync();
        }
        private IQueryable<T> GetData(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, int skip, int take, string includeProperties)
        {
            IQueryable<T> query = dbSet;

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
                query = orderBy(query).Select(p => p);
            }


            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {
                query = query.Take(take);
            }

            return query;
        }
        #endregion get
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }
        }
    }
}
