using LP.Common.Cqrs.Core.Commands;
using LP.Common.Cqrs.Core.Events;

namespace LP.Common.Cqrs.Core.Bus
{
    public interface IMessageBus : ICommandDispatcher, IEventPublisher
    {
    }
}