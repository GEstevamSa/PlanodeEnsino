using System;
using LP.Common.Repository.Contracts.Core.Entities;

namespace LP.Domain.Models
{
    public class User : DomainEntity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
