using Microsoft.Practices.Unity;
using Playground.CQRS.Infrastructure.CommandHandlers;
using Playground.CQRS.Infrastructure.Commands;
using Playground.CQRS.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Playground.CQRS.Configuration.Unity
{
    public class UnityCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IUnityContainer _container;

        public UnityCommandHandlerFactory(IUnityContainer container)
        {
            this._container = container;
        }

        public ICommandHandler<T> GetHandler<T>() where T : Command
        {
            var handlers = GetHandlerTypes<T>().ToList();

            var cmdHandler = handlers.Select(h =>
                (ICommandHandler<T>)this._container.Resolve(h))
                .FirstOrDefault();

            return cmdHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : Command
        {
            var assembly = Assembly.Load(new AssemblyName("Playground.CQRS.Domain"));


            var handlers = assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
                )
                .Where(h => h.GetInterfaces()
                    .Any(ii => ii.GetGenericArguments()
                        .Any(aa => aa == typeof(T))
                    )
                ).ToList();

            return handlers;
        }
    }
}
