using System;
using System.Collections.Generic;
using LP.ApplicationService.Interfaces;
using LP.ApplicationService.ViewModels;

namespace LP.Domain.Tests.Factories
{
  public class UserFactory
  {
    private readonly IUserAppService userAppService;

    public UserFactory(IUserAppService userAppService)
    {
      this.userAppService = userAppService;
    }

    public UserViewModel Login()
    {
      var viewModel = new UserViewModel()
      {
        Name = "Marcelo",
        Login = "marcelo@teste.com"
      };
      return Login(viewModel);
    }

    public UserViewModel Get(Guid id)
    {
      return userAppService.Get(id);
    }

    public IEnumerable<UserViewModel> GetAll()
    {
      return userAppService.GetAll();
    }

    public UserViewModel Login(UserViewModel viewModel)
    {
      var response = userAppService.Login(viewModel);
      return response;
    }
  }
}
