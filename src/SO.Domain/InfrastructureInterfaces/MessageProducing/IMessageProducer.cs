using System;
using System.Collections.Generic;
using System.Text;
using AMQPMessages.Messages;

namespace SO.Domain.InfrastructureInterfaces.MessageProducing
{
    public interface IMessageProducer
    {
        void ProduceCityCreated(CityCreatedMessage message);
    }
}
