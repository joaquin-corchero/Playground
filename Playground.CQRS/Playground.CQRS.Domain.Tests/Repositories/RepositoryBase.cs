using NBehave.Spec.MSTest;
using Playground.CQRS.Domain.Dtos;
using Playground.CQRS.Domain.Tests.EFMock;
using System.Collections.Generic;

namespace Playground.CQRS.Domain.Tests.Repositories
{
    public class RepositoryBase : SpecBase
    {
        protected MockDbContext _dbContext;

        protected override void Establish_context()
        {
            base.Establish_context();
            this._dbContext = new MockDbContext();
        }
    }
}
