using Playground.CQRS.Infrastructure.CommandValidators;
using System;
using System.Collections.Generic;

namespace Playground.CQRS.Infrastructure.CommandHandlers
{
    public class CommandHandlerException : Exception
    {
        private List<ValidationError> ValidationErrors;

        public CommandHandlerException(List<ValidationError> validationErrors)
        {
            this.ValidationErrors = validationErrors;
        }
    }
}
