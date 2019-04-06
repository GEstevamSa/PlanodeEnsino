using System.ComponentModel.DataAnnotations;
using LP.Common.Cqrs.Core.Commands;

namespace LP.Domain.CommandHandlers.User
{
    public class LoginUserCommand : Command
    {
        public LoginUserCommand(string name, string login)
        {
            Name = name;
            Login = login;
        }

        [MinLength(2)]
        [MaxLength(255)]
        [Required]
        public string Name { get; protected set; }

        [MinLength(2)] [MaxLength(255)] public string Login { get; protected set; }
    }
}