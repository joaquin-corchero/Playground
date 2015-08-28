using Playground.CQRS.Domain.Dtos;
using System;

namespace Playground.CQRS.Domain.Repositories
{
    public interface IQueryRepository<T> where T : BaseDto
    {
        T GetById(Guid uId);
    }

    public interface ICreateRepository<T> where T : BaseDto
    {
        void Create(T dto);

        T GetById(Guid uId);
    }

    public interface IUpdateRepository<T> where T : BaseDto
    {
        void Update(T dto);

        T GetById(Guid uId);
    }
}
