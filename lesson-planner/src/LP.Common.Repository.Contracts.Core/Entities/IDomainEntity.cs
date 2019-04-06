using System;

namespace LP.Common.Repository.Contracts.Core.Entities
{
    public interface IDomainEntity :
        IEntityWithPrimaryKey<Guid>,
        IEntityWithAudit
    {
    }
}