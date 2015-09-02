using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Web.Infrastructure;
using Playground.Async.Web.Infrastructure.Entities;
using System.Data.Entity;

namespace Playground.Async.Web.Tests.Infrastructure.Repositories
{
    public abstract class RepositoryBase : SpecBase
    {
        protected Mock<IAsyncDbContext> _dbContext = new Mock<IAsyncDbContext>();
        protected Mock<DbSet<Product>> _products;

        protected override void Establish_context()
        {
            base.Establish_context();

            InitializeDB();
        }

        private void InitializeDB()
        {
            _products = MockingHelper.AsMockDbSet(Data.Products);

            _dbContext.Setup(c => c.Set<Product>()).Returns(_products.Object);
        }
    }
}
