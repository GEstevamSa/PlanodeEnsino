using Autofac;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.Cqrs.Core.CommandHandlers;
using LP.Common.Cqrs.Core.Commands;
using LP.Common.Cqrs.Core.Events;
using LP.Common.Repository.Contracts.Core.Entities;
using LP.Common.Repository.Contracts.Core.Validations;
using Newtonsoft.Json;
using Serilog;
using System.Threading.Tasks;

namespace LP.Infrastructure.Bus
{
    public class InfraMessageBus : IMessageBus
    {
        private readonly IComponentContext context;
        private readonly ILogger logger = Log.ForContext<InfraMessageBus>();

        public InfraMessageBus(IComponentContext context)
        {
            this.context = context;
        }

        public Task<TEntity> DispatchCommandTwoWay<TCommand, TEntity>(TCommand command)
            where TCommand : ICommand where TEntity : IDomainEntity
        {
            command.RaiseExceptionIfModelIsNotValid();
            var entity = context.Resolve<ICommandHandlerTwoWay<TCommand, TEntity>>().Handle(command);
            LogMessage(command, JsonConvert.SerializeObject(entity.Result));
            return entity;
        }

        public Task DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            command.RaiseExceptionIfModelIsNotValid();
            LogMessage(command, "");
            return context.Resolve<ICommandHandler<TCommand>>().Handle(command);
        }

        public Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            @event.RaiseExceptionIfModelIsNotValid();
            return context.Resolve<IEventHandler<TEvent>>().Handle(@event);
        }        

        private void LogMessage<TCommand>(TCommand command, string outputData)
            where TCommand : ICommand 
        {
            var message = @"{messageType} {messageId} {inputData} {outputData}";
            var messageType = command.MessageType;
            var messageId = command.MessageId;
            var inputData = JsonConvert.SerializeObject(command);            

            logger.Write(Serilog.Events.LogEventLevel.Debug, message, messageType, messageId, inputData, outputData);
        }
    }
}
