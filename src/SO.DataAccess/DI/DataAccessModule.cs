using Autofac;
using SO.DataAccess.Repositories;
using SO.Domain.DataAccessInterfaces.Repository;

namespace SO.DataAccess.DI
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(EntityFrameworkRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}