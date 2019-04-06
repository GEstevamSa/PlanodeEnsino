using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using LP.ApplicationService.ViewModels;
using LP.Integration.Tests.Controllers;
using LP.Integration.Tests.Factories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LP.Accounting.FinancialStatements.Integration.Tests.Controllers
{
    public class UserControllerTest : BaseControllerTest
    {
        private readonly UserControllerFactory factory;

        public UserControllerTest()
        {
            factory = new UserControllerFactory(client);
        }

        [Test]
        public async Task WhenLoginNewUser_Then_ICanFindItById()
        {
            // Act
            var viewModelCreate = await factory.Login();
            var responseGet = await factory.Get(viewModelCreate.Id);

            var viewModelGet = JsonConvert.DeserializeObject<UserViewModel>(responseGet.Result.ToString());

            // Assert
            responseGet.StatusCode.Should().Be((int) HttpStatusCode.OK);
            viewModelGet.Should().BeOfType<UserViewModel>();
            viewModelGet.Id.Should().NotBeEmpty();
            viewModelGet.Id.Should().Be(viewModelCreate.Id);
            viewModelGet.Name.Should().Be(viewModelCreate.Name);
        }

        [Test]
        public async Task WhenLoginNewUserWithNoAllowedGroup_Then_Forbidden()
        {
            // Assert
            var viewModel = new UserViewModel
            {
                Name = "Marcelo",
                Login = "marcelo@teste.com"
            };

            // Act
            var responseCreate = await factory.Login(viewModel);

            // Assert
            responseCreate.StatusCode.Should().Be((int) HttpStatusCode.Unauthorized);
        }
    }
}
