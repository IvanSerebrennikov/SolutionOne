using Autofac;
using SO.Domain.UseCases.One;
using SO.Domain.UseCases.One.Interfaces;

namespace SO.Domain.DI
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<OneDataService>()
                .As<IOneDataService>()
                .InstancePerLifetimeScope();
        }
    }
}