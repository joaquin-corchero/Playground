using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Domain.Products;
using Playground.Async.Persistence;
using System.Data.Entity;

namespace Playground.Async.Tests.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase : SpecBase
    {
        protected Mock<IAsyncDbContext> _dbContext = new Mock<IAsyncDbContext>();
        protected Mock<DbSet<Domain.Products.Product>> _products;

        protected override void Establish_context()
        {
            base.Establish_context();

            InitializeDB();
        }

        private void InitializeDB()
        {
            _products = MockingHelper.AsMockDbSet(Data.Products);

            _dbContext.Setup(c => c.Set<Domain.Products.Product>()).Returns(_products.Object);
        }
    }
}
