using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Web.Infrastructure;
using Playground.Async.Web.Infrastructure.Entities;

namespace Playground.Async.Web.Tests.Infrastructure.Repositories
{
    public abstract class RepositoryBase : SpecBase
    {
        protected Mock<IAsyncDbContext> _dbContext = new Mock<IAsyncDbContext>();

        protected override void Establish_context()
        {
            base.Establish_context();

            InitializeDB();
        }

        private void InitializeDB()
        {
            var productDBSet = MockingHelper.AsMockDbSet(Data.Products);

            _dbContext.Setup(c => c.Set<Product>()).Returns(productDBSet.Object);
        }
    }
}
