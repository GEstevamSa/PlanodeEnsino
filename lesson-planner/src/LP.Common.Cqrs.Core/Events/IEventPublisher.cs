using System.Threading.Tasks;

namespace LP.Common.Cqrs.Core.Events
{
    public interface IEventPublisher
    {
        Task PublishEvent<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}