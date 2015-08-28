using Playground.CQRS.Infrastructure.Commands;
using System.Collections.Generic;

namespace Playground.CQRS.Infrastructure.CommandValidators
{
    public interface ICommandValidator<T> where T : Command
    {
        List<ValidationError> ValidationErrors { get; }

        bool IsValid { get; }

        void Validate(T command);
    }
}
