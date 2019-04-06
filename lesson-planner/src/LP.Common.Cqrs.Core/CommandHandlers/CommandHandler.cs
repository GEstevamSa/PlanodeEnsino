using System.Collections.Generic;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.Cqrs.Core.Events;

namespace LP.Common.Cqrs.Core.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IMessageBus bus;

        protected CommandHandler(IMessageBus bus)
        {
            this.bus = bus;
        }

        public void PublishEvents(IEnumerable<IEvent> eventsToPublish)
        {
            foreach (var evt in eventsToPublish) bus.PublishEvent(evt);
        }
    }
}