using Playground.Async.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Async.Domain.Repositories
{
    public interface IProductQueryRepository : IQueryRepository<Product>
    {
        Task<List<Product>> FilterByName(string name);
    }
}
