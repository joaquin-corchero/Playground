using Playground.Async.Domain.Products;

namespace Playground.Async.Domain.Repositories
{
    public interface IProductCommandRepository : ICommandRepository<Product>
    {
    }
}
