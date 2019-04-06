using System.Threading.Tasks;
using LP.Common.Cqrs.Core.Commands;
using LP.Common.Repository.Contracts.Core.Entities;

namespace LP.Common.Cqrs.Core.CommandHandlers
{
    public interface ICommandHandlerTwoWay<in TCommand, TDomainEntity>
        where TCommand : ICommand
        where TDomainEntity : IDomainEntity
    {
        Task<TDomainEntity> Handle(TCommand command);
    }
}