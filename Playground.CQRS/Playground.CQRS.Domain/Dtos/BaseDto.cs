using System;

namespace Playground.CQRS.Domain.Dtos
{
    public abstract class BaseDto
    {
        public DateTime CreationDate { get; private set; }

        public Guid UId { get; private set; }

        public BaseDto(Guid uId)
        {
            this.UId = uId;
            this.CreationDate = DateTime.Now;
        }
    }
}
