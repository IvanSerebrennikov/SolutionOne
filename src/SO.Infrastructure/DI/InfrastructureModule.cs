using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using SO.Domain.InfrastructureInterfaces.MessageProducing;
using SO.Infrastructure.MessageProducing;

namespace SO.Infrastructure.DI
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<DefaultObjectPoolProvider>()
                .As<ObjectPoolProvider>()
                .SingleInstance();

            builder
                .RegisterType<RabbitMQProducerChannelPooledObjectPolicy>()
                .As<IPooledObjectPolicy<IModel>>()
                .SingleInstance();

            builder
                .RegisterType<RabbitMQMessageProducer>()
                .As<IMessageProducer>()
                .SingleInstance();
        }
    }
}
