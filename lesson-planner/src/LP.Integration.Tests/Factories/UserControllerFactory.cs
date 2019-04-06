using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LP.ApplicationService.ViewModels;
using LP.Common.WebServer.Server;
using Newtonsoft.Json;

namespace LP.Integration.Tests.Factories
{
    public class UserControllerFactory
    {
        private const string url = "/api/User";
        private readonly HttpClient client;

        public UserControllerFactory(HttpClient client)
        {
            this.client = client;
        }

        public async Task<UserViewModel> Login()
        {
            //Arrange
            var model = new UserViewModel
            {
                Name = "Marcelo",
                Login = "marcelo@teste.com"
            };

            //Act
            var responseModel = await Login(model);
            var viewModel = JsonConvert.DeserializeObject<UserViewModel>(responseModel.Result.ToString());

            // Assert
            responseModel.StatusCode.Should().Be((int) HttpStatusCode.OK);
            viewModel.Should().BeOfType<UserViewModel>();

            viewModel.Id.Should().NotBeEmpty();

            return viewModel;
        }

        public async Task<ApiResponse> Get(Guid id)
        {
            // Act
            var response = await client.GetAsync($"{url}/{id}");
            var responseModel = JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());

            return responseModel;
        }

        public async Task<ApiResponse> Login(UserViewModel model)
        {
            // Arrange
            var requestBody = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync($"{url}/login", requestBody);

            // Assert
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());            
            return apiResponse;
        }
    }
}
