using System;
using System.Text;
using AMQPMessages.Messages;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SO.Domain.InfrastructureInterfaces.MessageProducing;

namespace SO.Infrastructure.MessageProducing
{
    public class RabbitMQMessageProducer : IMessageProducer
    {
        private readonly DefaultObjectPool<IModel> _channelsPool;

        public RabbitMQMessageProducer(IPooledObjectPolicy<IModel> channelPolicy)
        {
            _channelsPool = new DefaultObjectPool<IModel>(channelPolicy, Environment.ProcessorCount * 2);
        }

        public void ProduceCityCreated(CityCreatedMessage message)
        {
            Produce(message, "CityCreated");
        }

        private void Produce<T>(T message, string queueName)   
            where T : class  
        {  
            if (message == null)  
                return;  
  
            var channel = _channelsPool.Get();  
  
            try  
            {  
                channel.QueueDeclare(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
  
                var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));  
  
                var properties = channel.CreateBasicProperties(); 
                properties.Persistent = true;  
  
                channel.BasicPublish(
                    exchange: "",
                    routingKey: queueName,
                    basicProperties: properties,
                    body: sendBytes);
            }  
            catch (Exception ex)  
            {  
                throw ex;  
            }  
            finally  
            {  
                _channelsPool.Return(channel);                  
            }  
        }  
    }
}
