using System.Threading.Tasks;

namespace Playground.Async.Domain.Repositories
{
    public interface ICommandRepository<T> where T : class
    {
        T Add(T t);

        Task<T> Update(T updated, int key);
    }
}
