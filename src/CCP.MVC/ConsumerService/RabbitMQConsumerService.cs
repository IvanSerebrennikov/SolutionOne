using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AMQPSharedData;
using AMQPSharedData.Messages;
using CCP.MVC.AppSettings;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CCP.MVC.ConsumerService
{
    public class RabbitMQConsumerService : BackgroundService
    {
        private readonly RabbitMQSettings _settings;

        private IConnection _connection;

        public RabbitMQConsumerService(IOptions<RabbitMQSettings> settings)
        {
            _settings = settings.Value;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory()  
            {  
                HostName = _settings.HostName,  
                UserName = _settings.UserName,  
                Password = _settings.Password,  
                Port = _settings.Port,  
                VirtualHost = _settings.VHost,  
            };  

            // create connection  
            _connection = factory.CreateConnection();

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            ConsumeCityCreated();
            
            return Task.CompletedTask;
        }

        private void ConsumeCityCreated()
        {
            Consume<CityCreatedMessage>(Queues.CityCreated,
                message =>
                {
                    // TODO: ...
                });
        }

        private void Consume<T>(string queueName, Action<T> handler)   
            where T : class  
        {
            var channel = _connection.CreateModel();  
            channel.BasicQos(0, 1, false);
  
            try  
            {  
                channel.QueueDeclare(
                    queue: queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eArgs) =>
                {
                    // TODO: handle empty string and etc?

                    // received message  
                    var content = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(eArgs.Body));

                    // handle the received message  
                    handler(content);

                    channel.BasicAck(eArgs.DeliveryTag, false);
                };

                consumer.Shutdown += (sender, eArgs) => {};
                consumer.Registered += (sender, eArgs) => {};
                consumer.Unregistered += (sender, eArgs) => {};
                consumer.ConsumerCancelled += (sender, eArgs) => {};

                channel.BasicConsume(
                    queue: queueName,
                    autoAck: false,
                    consumer: consumer);

                // TODO: add channel to channels List as class prop to close in Dispose? 
            }  
            catch (Exception ex)  
            {  
                // channel.Close(); ??
                throw ex;  
            }  
            finally  
            {  
                                  
            }  
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs eArgs)
        {
        }

        public override void Dispose()
        {
            _connection.Close();
            base.Dispose();
        }
    }
}