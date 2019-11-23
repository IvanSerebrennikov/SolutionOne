using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using SO.Domain.AppSettings;

namespace SO.Infrastructure.MessageProducing
{
    public class RabbitMQProducerChannelPooledObjectPolicy : IPooledObjectPolicy<IModel>, IDisposable
    {
        private readonly RabbitMQSettings _settings;

        private readonly IConnection _connection;

        public RabbitMQProducerChannelPooledObjectPolicy(IOptions<RabbitMQSettings> settings)
        {
            _settings = settings.Value;
            _connection = GetConnection();  
        }  
  
        private IConnection GetConnection()  
        {  
            var factory = new ConnectionFactory()  
            {  
                HostName = _settings.HostName,  
                UserName = _settings.UserName,  
                Password = _settings.Password,  
                Port = _settings.Port,  
                VirtualHost = _settings.VHost,  
            };  
  
            return factory.CreateConnection();  
        }  

        public IModel Create()
        {
            return _connection.CreateModel();  
        }

        public bool Return(IModel obj)
        {
            if (obj.IsOpen)  
            {  
                return true;  
            }  
            else  
            {
                obj?.Close();  
                return false;  
            } 
        }

        public void Dispose()
        {
            _connection?.Close();
        }
    }
}
