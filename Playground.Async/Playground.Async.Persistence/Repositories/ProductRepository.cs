using Playground.Async.Domain.Products;
using Playground.Async.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        public async override Task<Product> Get(int id)
        {
            return await Find(p => p.ProductId == id);
        }
    }
}