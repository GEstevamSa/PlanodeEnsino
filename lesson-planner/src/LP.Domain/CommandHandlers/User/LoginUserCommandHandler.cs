using System;
using System.Threading.Tasks;
using LP.Domain.CommandHandlers.User;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.Cqrs.Core.CommandHandlers;
using LP.Common.Repository.Contracts.Core.Repository;

namespace LP.Domain.CommandHandlers.User
{
    public class LoginUserCommandHandler :
        CommandHandler,
        ICommandHandlerTwoWay<LoginUserCommand, Models.User>
    {
        private readonly IRepository<Models.User> userRepository;

        public LoginUserCommandHandler(IRepository<Models.User> userRepository, IMessageBus bus) : base(bus)
        {
            this.userRepository = userRepository;
        }

        public Task<Models.User> Handle(LoginUserCommand command)
        {
            return Task.Run(() =>
            {
                var currentUser = userRepository.Find(x => x.Login == command.Login);

                if (currentUser == null)
                {
                    //Domain Changes
                    currentUser = new Models.User
                    {
                        Name = command.Name,
                        Login = command.Login,
                        LastLogin = DateTime.UtcNow
                    };

                    //Persistence
                    userRepository.Insert(currentUser);
                }
                else
                {
                    var lastLogin = currentUser.LastLogin;

                    currentUser.LastLogin = DateTime.UtcNow;
                    userRepository.Update(currentUser);

                    currentUser.LastLogin = lastLogin;
                }

                return currentUser;
            });
        }
    }
}
