using System.Collections.Generic;

namespace LP.Common.Repository.Contracts.Core.Entities
{
    public interface IAggregateRoot
    {
        int Version { get; }
        IEnumerable<object> AppliedEvents { get; }
    }
}