using Microsoft.Practices.Unity;
using Playground.CQRS.Configuration.Unity;
using Playground.CQRS.Infrastructure.Messaging;

namespace Playground.CQRS.Configuration
{
    public partial class BootStrapper
    {
        public static void RegisterInfrastructure(IUnityContainer container)
        {
            container.RegisterType<ICommandHandlerFactory, UnityCommandHandlerFactory>(new InjectionConstructor(container));
            container.RegisterType<ICommandBus, CommandBus>();
        }
    }
}
