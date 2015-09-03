using Playground.Async.Domain.Products;
using Playground.Async.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Async.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductCommandRepository, IProductQueryRepository
    {
        public ProductRepository(IAsyncDbContext dbContext) : base(dbContext)
        {

        }

        public ProductRepository() : this(new AsyncDbContext())
        {

        }

        public async Task<List<Product>> FilterByName(string name)
        {
            return await base.FindAll(p => p.Name == name);
        }

    }
}