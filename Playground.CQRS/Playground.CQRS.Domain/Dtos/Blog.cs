
using System;
using System.Collections.Generic;
namespace Playground.CQRS.Domain.Dtos
{
    public class Blog : BaseDto
    {
        public int BlogId { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }

        public List<Post> Posts { get; private set; }

        public Blog(Guid uId, string name, string url)
            : base(uId)
        {
            this.Name = name;
            this.Url = url;
        }

        public void SetName(string newName)
        {
            this.Name = newName;
        }

        public void SetUrl(string newUrl)
        {
            this.Url = newUrl;
        }
    }
}