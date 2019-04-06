using System.Collections.Generic;
using Autofac;
using LP.ApplicationService.InjectionModules;
using LP.Domain.Tests.InjectionModules;

namespace LP.Domain.Tests.Models
{
    public class BaseDomainTests
    {
        protected IContainer container;

        public BaseDomainTests()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new IoCModuleApplicationService());
            builder.RegisterModule(new IoCAutoMapperModule());
            builder.RegisterModule(new IoCModuleDomainTest());

            container = builder.Build();
        }
    }
}
