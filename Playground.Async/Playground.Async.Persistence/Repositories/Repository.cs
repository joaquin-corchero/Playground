using Playground.Async.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Playground.Async.Persistence.Repositories
{
    public abstract class Repository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class
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

            return t;
        }

        public virtual async Task<T> Update(T updated, Guid key)
        {
            if (updated == null)
                throw new ArgumentNullException("No Item provided to update");

            if (key == new Guid())
                throw new ArgumentException(string.Format("Invalid Item Key passed {0}", key));

            T existing = await _dbSet.FindAsync(key);

            if (existing == null)
                throw new Exception(string.Format("Couldn't find the Item with Id {0}", key));

            if (existing != null)
                _context.Entry(existing).CurrentValues.SetValues(updated);

            return existing;
        }

        public virtual async Task<bool> Delete(T t)
        {
            _dbSet.Remove(t);

            return true;
        }

        public virtual async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
