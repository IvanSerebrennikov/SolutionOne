using Autofac;
using SO.Domain.UseCases._Base.Models.PostResults;
using SO.Domain.UseCases.Account;
using SO.Domain.UseCases.Account.Interfaces;
using SO.Domain.UseCases.Admin;
using SO.Domain.UseCases.Admin.Interfaces;
using SO.Domain.UseCases.One;
using SO.Domain.UseCases.One.Interfaces;

namespace SO.Domain.DI
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PostResultFactory>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<OneService>()
                .As<IOneService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AdminService>()
                .As<IAdminService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AccountService>()
                .As<IAccountService>()
                .InstancePerLifetimeScope();
        }
    }
}