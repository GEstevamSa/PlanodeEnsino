using Autofac;
using AutoMapper;
using LP.ApplicationService.Mappings;

namespace LP.ApplicationService.InjectionModules
{
    public class IoCAutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(
                    context => new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile(new DomainToViewModelMapping());
                        cfg.AddProfile(new ViewModelToDomainMapping());
                    }))
                .AsSelf().SingleInstance();

            builder.Register(
                    c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
