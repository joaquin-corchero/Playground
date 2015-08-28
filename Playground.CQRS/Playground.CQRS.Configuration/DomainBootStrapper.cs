using Microsoft.Practices.Unity;
using Playground.CQRS.Domain;
using Playground.CQRS.Domain.CommandHandlers;
using Playground.CQRS.Domain.Commands.BlogCommands;
using Playground.CQRS.Domain.CommandValidators;
using Playground.CQRS.Domain.Dtos;
using Playground.CQRS.Domain.Repositories;
using Playground.CQRS.Infrastructure.CommandHandlers;
using Playground.CQRS.Infrastructure.CommandValidators;
using System.Configuration;
using System.Diagnostics.Contracts;

namespace Playground.CQRS.Configuration
{
    public partial class BootStrapper
    {
        public static void RegisterDomain(IUnityContainer container)
        {
            Contract.Requires(container != null);
            RegisterContext(container);
            RegisterRepositories(container);
            RegisterCommandHandlers(container);
            RegisterCommandValidators(container);
        }

        private static void RegisterContext(IUnityContainer container)
        {
            Contract.Requires(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString != null);
            container.RegisterType<IAppDbContext, AppDbContext>(new InjectionConstructor(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IBlogQueryRepository, BlogRepository>();
            container.RegisterType<ICreateRepository<Blog>, BlogRepository>();
            container.RegisterType<IUpdateRepository<Blog>, BlogRepository>();
        }

        private static void RegisterCommandHandlers(IUnityContainer container)
        {
            container.RegisterType<ICommandHandler<CreateBlogCommand>, BlogCommandHandler>();
        }

        private static void RegisterCommandValidators(IUnityContainer container)
        {
            container.RegisterType<ICommandValidator<CreateBlogCommand>, BlogCommandValidator>();
        }
    }
}
