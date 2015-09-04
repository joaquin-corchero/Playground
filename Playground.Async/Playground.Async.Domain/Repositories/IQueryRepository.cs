using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Async.Domain.Repositories
{
    public interface IQueryRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
    }
}