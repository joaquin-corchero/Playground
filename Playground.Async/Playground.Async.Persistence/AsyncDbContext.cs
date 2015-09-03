using Playground.Async.Domain.Products;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Playground.Async.Persistence
{
    public interface IAsyncDbContext
    {
        Task<int> SaveChangesAsync();

        DbEntityEntry Entry(object entity);

        DbSet<T> Set<T>() where T : class;
    }

    public class AsyncDbContext : DbContext, IAsyncDbContext
    {
        public virtual DbSet<Product> Products { get; set; }
    }
}
