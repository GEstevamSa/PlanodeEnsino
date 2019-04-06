using System;
using System.ComponentModel.DataAnnotations;

namespace LP.Common.Repository.Contracts.Core.Entities
{
    public abstract class SimpleDomainEntity : IEntityWithPrimaryKey<Guid>
    {
        [Key] public Guid Id { get; set; }
    }
}