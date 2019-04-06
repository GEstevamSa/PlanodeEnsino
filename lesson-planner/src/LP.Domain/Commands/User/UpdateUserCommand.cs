using System;
using System.ComponentModel.DataAnnotations;
using LP.Common.Cqrs.Core.Commands;

namespace LP.Domain.CommandHandlers.User
{
    public class UpdateUserCommand : Command
    {
        public UpdateUserCommand(Guid id, string name, string login, DateTime lastLogin)
        {
            Id = id;
            Name = name;
            Login = login;
            LastLogin = lastLogin;
        }

        [Required] public Guid Id { get; protected set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; protected set; }

        [MinLength(2)] [MaxLength(255)] public string Login { get; protected set; }

        [Required] public DateTime LastLogin { get; protected set; }
    }
}