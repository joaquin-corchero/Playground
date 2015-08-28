using Playground.CQRS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Playground.CQRS.Domain.Repositories
{
    public interface IBlogQueryRepository : IQueryRepository<Blog>
    {
        List<Blog> GetLatest();
    }

    public class BlogRepository : RepositoryBase, IBlogQueryRepository, ICreateRepository<Blog>, IUpdateRepository<Blog>
    {
        private const int _latestNumbers = 10;


        public BlogRepository(IAppDbContext dbContext)
            : base(dbContext)
        { }

        public List<Blog> GetLatest()
        {
            return base._dbContext.Blogs
                .OrderByDescending(b => b.CreationDate)
                .Take(_latestNumbers)
                .ToList();
        }

        public void Create(Blog blog)
        {
            base._dbContext.Blogs.Add(blog);
            base._dbContext.SaveChanges();
        }

        public void Update(Blog blog)
        {
            var existingItem = base._dbContext.Blogs.FirstOrDefault(b => b.UId == blog.UId);
            if (existingItem == null)
                throw new Exception("The blog couldn't be found");

            base._dbContext.Blogs.Attach(blog);
            base._dbContext.SaveChanges();
        }

        public Blog GetById(Guid uId)
        {
            return base._dbContext.Blogs
              .FirstOrDefault(b => b.UId == uId);
        }
    }
}