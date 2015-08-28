using System;

namespace Playground.CQRS.Infrastructure.Commands
{
    public class Command : ICommand
    {
        public Guid Id { get; private set; }

        public Command(Guid id)
        {
            this.Id = id;
        }
    }
}
