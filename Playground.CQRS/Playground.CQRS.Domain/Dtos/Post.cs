
using System;
namespace Playground.CQRS.Domain.Dtos
{
    public class Post : BaseDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public Post(Guid uId)
            : base(uId)
        {
        }

    }
}
