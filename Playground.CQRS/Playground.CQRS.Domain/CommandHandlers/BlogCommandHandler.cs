using Playground.CQRS.Domain.Commands.BlogCommands;
using Playground.CQRS.Domain.Dtos;
using Playground.CQRS.Domain.Repositories;
using Playground.CQRS.Infrastructure.CommandHandlers;
using System.Diagnostics.Contracts;

namespace Playground.CQRS.Domain.CommandHandlers
{
    public class BlogCommandHandler : ICommandHandler<CreateBlogCommand>, ICommandHandler<UpdateBlogCommand>
    {
        private readonly ICreateRepository<Blog> _insertRepository;
        private readonly IUpdateRepository<Blog> _updateRepository;

        public BlogCommandHandler(ICreateRepository<Blog> insertRepository, IUpdateRepository<Blog> updateRepository)
        {
            Contract.Requires(insertRepository != null);
            Contract.Requires(updateRepository != null);

            this._insertRepository = insertRepository;
            this._updateRepository = updateRepository;
        }

        public void Execute(CreateBlogCommand command)
        {
            Contract.Requires(command != null);

            var item = new Blog(command.Id, command.Name, command.Url);
            this._insertRepository.Create(item);
        }

        public void Execute(UpdateBlogCommand command)
        {
            Contract.Requires(command != null);

            var item = new Blog(command.Id, command.Name, command.Url);
            this._updateRepository.Update(item);
        }
    }
}