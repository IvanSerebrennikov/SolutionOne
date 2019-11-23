using System;
using System.Collections.Generic;
using System.Text;
using AMPQMessages.Messages;
using SO.Domain.InfrastructureInterfaces.MessageProducing;

namespace SO.Infrastructure.MessageProducing
{
    public class RabbitMQMessageProducer : IMessageProducer
    {
        public void ProduceCityCreated(CityCreatedMessage message)
        {
            // ...
        }
    }
}
