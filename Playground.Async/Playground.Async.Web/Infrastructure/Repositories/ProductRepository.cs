using Playground.Async.Web.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Async.Web.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> FilterByName(string name);
    }


    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IAsyncDbContext context) : base(context)
        {
        }

        public Task<List<Product>> FilterByName(string name)
        {
            return base.FindAll(p => p.Name == name);
        }

    }
}