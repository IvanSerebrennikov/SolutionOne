using System;
using System.Collections.Generic;
using System.Text;
using AMQPMessages.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SO.Domain.InfrastructureInterfaces.MessageProducing;

namespace SO.Infrastructure.MessageProducing
{
    public class RabbitMQMessageProducer : IMessageProducer
    {
        public void ProduceCityCreated(CityCreatedMessage message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "CityCreatedTest",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish(
                exchange: "",
                routingKey: "CityCreatedTest",
                basicProperties: null,
                body: body);
        }
    }
}
