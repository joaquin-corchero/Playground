
using Playground.CQRS.Domain.Dtos;
using System.Data.Entity;

namespace Playground.CQRS.Domain
{
    public interface IAppDbContext
    {
        IDbSet<Blog> Blogs { get; }

        IDbSet<Post> Posts { get; }

        int SaveChanges();
    }

    public class AppDbContext : DbContext, IAppDbContext
    {
        public virtual IDbSet<Blog> Blogs { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        int IAppDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }

        public AppDbContext(string connectionString)
            : base(connectionString)
        { }
    }
}
