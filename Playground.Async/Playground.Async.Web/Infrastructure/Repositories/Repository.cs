using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Playground.Async.Web.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T t);
        Task<int> Count();
        Task<int> Delete(T t);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<T> Update(T updated, int key);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected IAsyncDbContext _context;
        protected DbSet<T> _dbSet;

        public Repository(IAsyncDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        protected async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await _dbSet.SingleOrDefaultAsync(match);
        }

        protected async Task<List<T>> FindAll(Expression<Func<T, bool>> match)
        {
            return await _dbSet.Where(match).ToListAsync();
        }

        public virtual async Task<T> Add(T t)
        {
            _dbSet.Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public virtual async Task<T> Update(T updated, int key)
        {
            if (updated == null)
                return null;

            T existing = await _dbSet.FindAsync(key);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(updated);
                await _context.SaveChangesAsync();
            }
            return existing;
        }

        public virtual async Task<int> Delete(T t)
        {
            _dbSet.Remove(t);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }
    }
}