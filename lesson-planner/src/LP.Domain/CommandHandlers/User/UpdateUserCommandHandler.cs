using System.Threading.Tasks;
using LP.Domain.CommandHandlers.User;
using LP.Common.Cqrs.Core.Bus;
using LP.Common.Cqrs.Core.CommandHandlers;
using LP.Common.Repository.Contracts.Core.Repository;

namespace LP.Domain.CommandHandlers.User
{
    internal class UpdateUserCommandHandler :
        CommandHandler,
        ICommandHandlerTwoWay<UpdateUserCommand, Models.User>
    {
        private readonly IRepository<Models.User> userLibRepository;

        public UpdateUserCommandHandler(IRepository<Models.User> userLibRepository, IMessageBus bus) : base(bus)
        {
            this.userLibRepository = userLibRepository;
        }

        public Task<Models.User> Handle(UpdateUserCommand command)
        {
            return Task.Run(() =>
            {
                //Domain Changes
                var user = userLibRepository.FindById(command.Id);
                user.Name = command.Name;
                user.Login = command.Login;
                user.LastLogin = command.LastLogin;

                //Persistence
                userLibRepository.Update(user);

                return user;
            });
        }
    }
}
