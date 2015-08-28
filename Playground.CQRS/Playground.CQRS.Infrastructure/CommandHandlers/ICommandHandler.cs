using Playground.CQRS.Infrastructure.Commands;

namespace Playground.CQRS.Infrastructure.CommandHandlers
{
    public interface ICommandHandler<T> where T : Command
    {
        void Execute(T command);
    }
}
