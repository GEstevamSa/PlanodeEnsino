using System.Threading.Tasks;
using LP.Domain.CommandHandlers.User;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.Cqrs.Core.CommandHandlers;
using LP.Common.Repository.Contracts.Core.Repository;

namespace LP.Domain.CommandHandlers.User
{
    public class DeleteUserCommandHandler :
        CommandHandler,
        ICommandHandler<DeleteUserCommand>
    {
        private readonly IRepository<Models.User> userRepository;

        public DeleteUserCommandHandler(IRepository<Models.User> userRepository, IMessageBus bus) : base(bus)
        {
            this.userRepository = userRepository;
        }

        public Task Handle(DeleteUserCommand command)
        {
            //Persistence
            userRepository.Delete(command.Id);

            return Task.CompletedTask;
        }
    }
}
