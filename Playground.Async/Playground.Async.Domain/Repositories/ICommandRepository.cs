using System;
using System.Threading.Tasks;

namespace Playground.Async.Domain.Repositories
{
    public interface ICommandRepository<T> where T : class
    {
        Task<T> Add(T t);

        Task<bool> Delete(T t);

        Task<T> Update(T updated, Guid key);

        Task<int> SaveChanges();
    }
}
