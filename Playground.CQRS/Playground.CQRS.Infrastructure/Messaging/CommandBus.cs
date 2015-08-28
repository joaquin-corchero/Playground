
using Playground.CQRS.Infrastructure.Commands;
using System;
using System.Collections.Generic;

namespace Playground.CQRS.Infrastructure.Messaging
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            this._commandHandlerFactory = commandHandlerFactory;
        }


        public void Execute<T>(T command) where T : Command
        {
            var handler = _commandHandlerFactory.GetHandler<T>();
            if (handler == null)
                throw new Exception("no handler registered");

            handler.Execute(command);
        }    
    }
}