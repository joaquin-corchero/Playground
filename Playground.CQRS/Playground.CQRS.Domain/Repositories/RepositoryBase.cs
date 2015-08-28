
namespace Playground.CQRS.Domain.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IAppDbContext _dbContext;

        public RepositoryBase(IAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
