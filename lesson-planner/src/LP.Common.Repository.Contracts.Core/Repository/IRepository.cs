using System;
using LP.Common.Repository.Contracts.Core.Entities;

namespace LP.Common.Repository.Contracts.Core.Repository
{
    public interface IRepository<TEntity> :
        IPersistenceService<TEntity>,
        IQueryService<TEntity>, IDisposable where TEntity : IDomainEntity
    {
    }
}