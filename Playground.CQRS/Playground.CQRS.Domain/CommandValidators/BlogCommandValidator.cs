using Playground.CQRS.Domain.Commands.BlogCommands;
using Playground.CQRS.Infrastructure.CommandValidators;
using System.Collections.Generic;

namespace Playground.CQRS.Domain.CommandValidators
{
    public class BlogCommandValidator : ICommandValidator<CreateBlogCommand>, ICommandValidator<UpdateBlogCommand>
    {
        public List<ValidationError> ValidationErrors { get; private set; }

        public bool IsValid
        {
            get { return this.ValidationErrors.Count == 0; }
        }

        public BlogCommandValidator()
        {
            this.ValidationErrors = new List<ValidationError>();
        }

        private void ValidateCreateOrUpdate(CreateBlogCommand command)
        {
            if (string.IsNullOrEmpty(command.Name))
                this.ValidationErrors.Add(new ValidationError("Name", "The blog Name can't be empty"));

            if (string.IsNullOrEmpty(command.Url))
                this.ValidationErrors.Add(new ValidationError("Url", "The blog Url can't be empty"));

            if (!this.IsValid)
                return;

            if (command.Name.Length < 5 || command.Name.Length > 20)
                this.ValidationErrors.Add(new ValidationError("Name", "The blog Name must be between 5 and 20 characters long"));

            if (command.Url.Length < 8 || command.Url.Length > 500)
                this.ValidationErrors.Add(new ValidationError("Url", "The blog Name must be between 8 and 500 characters long"));
        }

        public void Validate(CreateBlogCommand command)
        {
            this.ValidateCreateOrUpdate(command);
        }

        public void Validate(UpdateBlogCommand command)
        {
            //this.ValidateCreateOrUpdate(command);
        }
    }
}
