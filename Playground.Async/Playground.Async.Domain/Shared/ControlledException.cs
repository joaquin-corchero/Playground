using System;

namespace Playground.Async.Domain.Shared
{
    public class ControlledException : Exception
    {
        public ControlledException(string message) : base(message)
        {
        }
    }
}
