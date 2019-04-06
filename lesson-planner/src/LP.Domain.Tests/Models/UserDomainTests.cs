using System;
using System.Collections.Generic;
using Autofac;
using FluentAssertions;
using LP.ApplicationService.ViewModels;
using LP.Domain.Tests.Factories;
using LP.Common.Repository.Contracts.Core.Exceptions;
using NUnit.Framework;

namespace LP.Domain.Tests.Models
{
    [TestFixture]
    public class UserDomainTests : BaseDomainTests
    {
        private readonly UserFactory userFactory;

        public UserDomainTests()
        {
            userFactory = container.Resolve<UserFactory>();
        }

        [Test]
        public void WhenLoginNewEmptyUser_Then_Error()
        {
            //arrange
            var viewModel = new UserViewModel();

            //act
            Action action = () => { userFactory.Login(viewModel); };

            //assert
            action.Should()
                .Throw<ModelException>()
                .WithMessage(
                    "This object instance is not valid based on DataAnnotation definitions. See more details on Errors list.");
        }

        [Test]
        public void WhenLoginNewUser_Then_ICanFindItById()
        {
            //arrange
            var viewModel = new UserViewModel
            {
                Name = "Marcelo",
                Login = "marcelo@teste.com"
            };

            //act
            var responseCreate = userFactory.Login(viewModel);
            var responseFindById = userFactory.Get(responseCreate.Id);

            //assert
            responseFindById.Id.Should().Be(responseCreate.Id);
            responseFindById.Name.Should().Be(responseCreate.Name);
        }

        [Test]
        public void WhenLoginNewUserWithNotAllowedGroup_Then_Forbidden()
        {
            //arrange
            var viewModel = new UserViewModel
            {
                Name = "Marcelo",
                Login = "marcelo@teste.com"
            };

            //act
            var responseCreate = userFactory.Login(viewModel);

            //assert
            responseCreate.Should().BeNull();
        }
    }
}
