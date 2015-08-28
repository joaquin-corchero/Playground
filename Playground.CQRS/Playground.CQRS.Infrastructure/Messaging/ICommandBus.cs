using Playground.CQRS.Infrastructure.Commands;
using System.Collections.Generic;

namespace Playground.CQRS.Infrastructure.Messaging
{
    public interface ICommandBus
    {
        void Execute<T>(T command) where T : Command;
    }
}
