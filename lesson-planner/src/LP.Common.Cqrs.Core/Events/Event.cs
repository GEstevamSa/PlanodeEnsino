using LP.Common.Cqrs.Core.Bus;

namespace LP.Common.Cqrs.Core.Events
{
    public abstract class Event : Message, IEvent
    {
    }
}