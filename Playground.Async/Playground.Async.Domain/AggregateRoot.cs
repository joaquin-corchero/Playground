using System;

namespace Playground.Async.Domain
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        protected AggregateRoot()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}