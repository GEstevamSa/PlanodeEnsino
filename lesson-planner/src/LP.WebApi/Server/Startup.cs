using Autofac;
using LP.ApplicationService.InjectionModules;
using LP.DbEFCore.Repositories;
using LP.Infrastructure.InjectionModules;
using LP.WebApi.Server.Middlewares;
using LP.Common.Logger.Serilog.Server.Middlewares;
using LP.Common.WebServer.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace LP.WebApi.Server
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            Log.Information($"Starting up {env.ApplicationName}");
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // IoC Container Module Registration
            builder.RegisterModule(new IoCModuleApplicationService());
            builder.RegisterModule(new IoCModuleInfrastructure());
            builder.RegisterModule(new IoCAutoMapperModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<EfCoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LPConnection"));
            });

            services
                .AddMvc(options => { options.Filters.Add(typeof(ValidateModelAttribute)); })
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info {Title = "LP Swagger Documentation", Version = "v1"});                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IHttpContextAccessor accessor)
        {
            loggerFactory.AddSerilog();
            app.UseMiddleware<SerilogMiddleware>();
            app.UseApiResponseWrapperMiddleware();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("Content-Disposition"));

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });

            // Enable middleware to serve swagger-ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "LP Documentation");
            });

            UpdateDatabaseUsingEfCore(app);
        }

        private void UpdateDatabaseUsingEfCore(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetRequiredService<EfCoreDbContext>()
                    .Database
                    .Migrate();
            }
        }
    }
}
