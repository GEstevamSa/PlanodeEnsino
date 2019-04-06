using System;
using System.Collections.Generic;
using LP.ApplicationService.ViewModels;
using LP.Domain.CommandHandlers.User;

namespace LP.ApplicationService.Interfaces
{
    public interface IUserAppService
    {
        UserViewModel Get(Guid id);
        IEnumerable<UserViewModel> GetAll();        
        UserViewModel Login(UserViewModel viewModel);
    }
}
