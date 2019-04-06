using System.Threading.Tasks;
using LP.Common.Cqrs.Core.Commands;

namespace LP.Common.Cqrs.Core.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}