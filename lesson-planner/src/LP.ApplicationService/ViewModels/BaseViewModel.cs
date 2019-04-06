using System;
using LP.Common.Repository.Contracts.Core.Entities;

namespace LP.ApplicationService.ViewModels
{
    public abstract class BaseViewModel : IBaseViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string AuditUserName { get; set; }

        public bool IsActive { get; set; }
    }   
}
