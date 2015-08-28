using Playground.CQRS.Infrastructure.CommandHandlers;
using Playground.CQRS.Infrastructure.Commands;

namespace Playground.CQRS.Infrastructure.Messaging
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
