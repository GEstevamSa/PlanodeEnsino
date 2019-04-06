using System.Threading.Tasks;
using LP.Common.Repository.Contracts.Core.Entities;

namespace LP.Common.Cqrs.Core.Commands
{
    public interface ICommandDispatcher
    {
        Task<TEntity> DispatchCommandTwoWay<TCommand, TEntity>(TCommand command)
            where TCommand : ICommand
            where TEntity : IDomainEntity;

        Task DispatchCommand<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}