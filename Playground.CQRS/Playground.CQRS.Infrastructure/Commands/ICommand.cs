using System;

namespace Playground.CQRS.Infrastructure.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
