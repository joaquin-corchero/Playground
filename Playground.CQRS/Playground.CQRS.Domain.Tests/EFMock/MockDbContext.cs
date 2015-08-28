using Playground.CQRS.Domain.Dtos;
using System.Data.Entity;

namespace Playground.CQRS.Domain.Tests.EFMock
{
    public class MockDbContext : IAppDbContext
    {
        public IDbSet<Blog> Blogs { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public int SaveChanges()
        {
            return 1;
        }

        public MockDbContext()
        {
            this.Blogs = new MockDbSet<Blog>();
            this.Posts = new MockDbSet<Post>();
        }
    }
}
