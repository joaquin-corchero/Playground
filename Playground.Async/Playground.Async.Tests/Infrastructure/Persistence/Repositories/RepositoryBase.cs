﻿using Moq;
using NBehave.Spec.MSTest;
using Playground.Async.Persistence;
using System.Data.Entity;

namespace Playground.Async.Tests.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase : SpecBase
    {
        protected Mock<IAsyncDbContext> _dbContext = new Mock<IAsyncDbContext>();
        protected Mock<DbSet<Domain.Products.Product>> _productsDbSet;

        protected override void Establish_context()
        {
            base.Establish_context();

            InitializeDB();
        }

        private void InitializeDB()
        {
            _productsDbSet = MockingHelper.AsMockDbSet(Data.Products);

            _dbContext.Setup(c => c.Set<Domain.Products.Product>()).Returns(_productsDbSet.Object);
            _dbContext.Setup(c => c.Entry(It.IsAny<object>()))
                .Callback((object entity) => { });
        }
    }
}
