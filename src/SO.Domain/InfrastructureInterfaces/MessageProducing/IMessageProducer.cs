using System;
using System.Collections.Generic;
using System.Text;
using AMPQMessages.Messages;

namespace SO.Domain.InfrastructureInterfaces.MessageProducing
{
    public interface IMessageProducer
    {
        void ProduceCityCreated(CityCreatedMessage message);
    }
}
