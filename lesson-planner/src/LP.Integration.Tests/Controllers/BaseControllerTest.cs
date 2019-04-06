using System;
using System.IO;
using System.Net.Http;
using Autofac.Extensions.DependencyInjection;
using LP.Integration.Tests.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace LP.Integration.Tests.Controllers
{
    public class BaseControllerTest : IDisposable
    {
        protected readonly HttpClient client;
        protected readonly TestServer server;

        public BaseControllerTest()
        {
            // Arrange
            server = new TestServer(new WebHostBuilder()
                .ConfigureServices(s => s.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<StartupAppForTests>());

            client = server.CreateClient();
        }

        public void Dispose()
        {
            client.Dispose();
            server.Dispose();
        }
    }
}
