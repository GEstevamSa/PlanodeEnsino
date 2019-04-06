using Autofac;
using LP.DbEFCore.Repositories;
using LP.Infrastructure.Bus;
using LP.Common.Repository.EFCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Module = Autofac.Module;

namespace LP.Infrastructure.InjectionModules
{
    public class IoCModuleInfrastructure : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // ASP.NET HttpContext dependency
            builder.RegisterType<HttpContextAccessor>().AsImplementedInterfaces();

            //Services
            var assemblyToScan = Assembly.GetAssembly(typeof(InfraMessageBus));
            builder
               .RegisterAssemblyTypes(assemblyToScan)
               .Where(c => c.IsClass
                           && c.IsInNamespace("LP.Infrastructure.Services"))
               .AsImplementedInterfaces();  

            // Service Bus
            builder.RegisterType<InfraMessageBus>().AsImplementedInterfaces();

            // Infra - Data
            builder.RegisterType<EfCoreDbContext>().As<DbContext>();

            builder
                .RegisterGeneric(typeof(EfCoreRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
