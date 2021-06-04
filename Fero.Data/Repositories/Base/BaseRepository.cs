﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using t = System.Threading.Tasks;

namespace Fero.Data.Repository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        int Count();
        T Get<TKey>(TKey id);
        t.Task<T> GetAsyn<TKey>(TKey id);
        IQueryable<T> Get();
        T FirstOrDefault();
        t.Task<T> FirstOrDefaultAsyn();
        void Create(T entity);
        t.Task CreateAsyn(T entity);
        void Update(T entity);
        //void Update(Expression<Func<T, bool>> predicate);
        void Delete(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsyn(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DbContext _dbContext;

        protected DbSet<T> _dbSet;
        public BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = this._dbContext.Set<T>();
        }
        public int Count()
        {
            return _dbSet.Count();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public async t.Task CreateAsyn(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T FirstOrDefault()
        {
            return this._dbSet.FirstOrDefault();
        }

        public Task<T> FirstOrDefaultAsyn()
        {
            throw new NotImplementedException();
        }

        public T Get<TKey>(TKey id)
        {
            return (T)this._dbSet.Find(new object[1] { id });
        }

        public IQueryable<T> Get()
        {
            return _dbSet;
        }

        public async t.Task<T> GetAsyn<TKey>(TKey id)
        {
            return await this._dbSet.FindAsync(new object[1] { id });
        }

/*        public void Update(T entity, Expression<Func<T, bool>> predicate)
        {
            _dbSet.Find(predicate).Update<T>(entity);
        }*/

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Where(predicate);
        } 
        public async Task<T> FirstOrDefaultAsyn(Expression<Func<T, bool>> predicate)
        {
            return await this._dbSet.FirstOrDefaultAsync(predicate);
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.FirstOrDefault(predicate);
        }
    }
        
}
