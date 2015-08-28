using Playground.CQRS.Infrastructure.Commands;
using System;
using System.Diagnostics.Contracts;

namespace Playground.CQRS.Domain.Commands.BlogCommands
{
    public class UpdateBlogCommand : Command
    {
        public string Name { get; private set; }

        public string Url { get; private set; }

        public UpdateBlogCommand(Guid uId, string name, string url)
            : base(uId)
        {
            Contract.Requires(uId != null);
            Contract.Requires(uId != new Guid());
            Contract.Requires(!string.IsNullOrEmpty(name));
            Contract.Requires(name.Length > 3);
            Contract.Requires(!string.IsNullOrEmpty(url));
            Contract.Requires(url.Length > 6);

            this.Name = name;
            this.Url = url;
        }
    }
}