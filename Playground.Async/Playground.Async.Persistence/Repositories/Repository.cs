using Playground.Async.Domain.Repositories;
using Playground.Async.Domain.Shared;
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
        protected IAsyncDbContext _dbContext;
        protected DbSet<T> _dbSet;

        public Repository(IAsyncDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public abstract Task<T> Get(int id);

        protected async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await _dbSet.SingleOrDefaultAsync(match);
        }

        protected async Task<List<T>> FindAll(Expression<Func<T, bool>> match)
        {
            return await _dbSet.Where(match).ToListAsync();
        }

        public virtual T Add(T t)
        {
            _dbSet.Add(t);

            return t;
        }

        public virtual async Task<T> Update(T updated, int key)
        {
            if (updated == null)
                throw new ControlledException("No Item provided to update");

            if (key < 1)
                throw new ControlledException(string.Format("Invalid Item Key passed {0}", key));

            T existing = await _dbSet.FindAsync(key);

            if (existing == null)
                throw new ControlledException(string.Format("Couldn't find the Item with Id {0}", key));

            _dbSet.Attach(updated);
            _dbContext.SetModified(updated);

            return updated;
        }
    }
}
