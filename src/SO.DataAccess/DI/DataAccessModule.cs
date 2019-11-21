using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SO.DataAccess.DbContext;
using SO.DataAccess.Repositories;
using SO.Domain.DataAccessInterfaces.Repository;

namespace SO.DataAccess.DI
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c =>
                {
                    var configuration = c.Resolve<IConfiguration>();

                    var optionsBuilder = new DbContextOptionsBuilder<SolutionOneDbContext>();

                    SolutionOneDbContextOptionsConfiguration.Configure(optionsBuilder, configuration);

                    return new SolutionOneDbContext(optionsBuilder.Options);
                })
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(EntityFrameworkRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}