using System;

namespace LP.Common.Cqrs.Core.Bus
{
    public interface IMessage
    {
        Guid MessageId { get; }
        string AuditUserName { get; set; }
        string MessageType { get; }
        DateTime MessageCreatedDate { get; }
    }
}
