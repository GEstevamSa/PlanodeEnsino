using System.Reflection;
using Autofac;
using LP.ApplicationService.Services;
using LP.Domain.InjectionModules;
using LP.Common.WebServer.Server;
using Module = Autofac.Module;

namespace LP.ApplicationService.InjectionModules
{
    public class IoCModuleApplicationService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Domain Modules: Command and CommandHandlers
            builder.RegisterModule<IoCModuleDomain>();

            var assemblyToScan = Assembly.GetAssembly(typeof(BaseAppService));

            builder
                .RegisterAssemblyTypes(assemblyToScan)
                .Where(c => c.IsClass
                            && c.IsInNamespace("LP.Accounting.FinancialStatements.ApplicationService.Services"))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(assemblyToScan)
                .Where(c => c.IsClass
                            && c.IsInNamespace("LP.Accounting.FinancialStatements.ApplicationService.Builders"))
                .AsImplementedInterfaces();

            builder.RegisterType<UserContext>().AsSelf();
        }
    }
}
