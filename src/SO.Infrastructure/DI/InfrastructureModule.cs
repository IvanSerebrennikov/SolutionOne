using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SO.Domain.InfrastructureInterfaces.MessageProducing;
using SO.Infrastructure.MessageProducing;

namespace SO.Infrastructure.DI
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RabbitMQMessageProducer>()
                .As<IMessageProducer>()
                .InstancePerLifetimeScope();
        }
    }
}
