using LP.Common.Cqrs.Core.Bus;

namespace LP.Common.Cqrs.Core.Commands
{
    public abstract class Command : Message, ICommand
    {
    }
}