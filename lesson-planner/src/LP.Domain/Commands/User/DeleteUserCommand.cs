using System;
using System.ComponentModel.DataAnnotations;
using LP.Common.Cqrs.Core.Commands;

namespace LP.Domain.CommandHandlers.User
{
    public class DeleteUserCommand : Command
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        [Required] public Guid Id { get; protected set; }
    }
}