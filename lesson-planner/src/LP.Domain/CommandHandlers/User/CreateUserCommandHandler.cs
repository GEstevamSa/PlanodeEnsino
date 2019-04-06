using System;
using System.Threading.Tasks;
using LP.Domain.CommandHandlers.User;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.Cqrs.Core.CommandHandlers;
using LP.Common.Repository.Contracts.Core.Repository;

namespace LP.Domain.CommandHandlers.User
{
    public class CreateUserCommandHandler :
        CommandHandler,
        ICommandHandlerTwoWay<CreateUserCommand, Models.User>
    {
        private readonly IRepository<Models.User> userRepository;

        public CreateUserCommandHandler(IRepository<Models.User> userRepository, IMessageBus bus) : base(bus)
        {
            this.userRepository = userRepository;
        }

        public Task<Models.User> Handle(CreateUserCommand command)
        {
            return Task.Run(() =>
            {
                //Domain Changes
                var user = new Models.User
                {
                    Name = command.Name,
                    Login = command.Login,
                    LastLogin = DateTime.UtcNow
                };

                //Persistence
                userRepository.Insert(user);

                return user;
            });
        }
    }
}
