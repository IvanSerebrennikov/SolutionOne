using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AMQPSharedData;
using AMQPSharedData.Messages;
using CityProcessor.AppSettings;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CityProcessor.ConsumerService
{
    public class RabbitMQConsumerService : BackgroundService
    {
        #region Fields

        private readonly RabbitMQSettings _settings;

        private IConnection _connection;

        private readonly List<IModel> _channels = new List<IModel>();

        #endregion

        #region Ctor and Init

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

            _connection = factory.CreateConnection();

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        #endregion

        private void ConsumeCityCreated()
        {
            Consume<CityCreatedMessage>(Queues.CityCreated,
                message =>
                {
                    if (message == null)
                    {
                        // TODO: ...
                        return;
                    }

                    // TODO: ...
                });
        }

        #region Methods for internal usage

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            ConsumeCityCreated();
            
            return Task.CompletedTask;
        }

        private void Consume<T>(string queueName, Action<T> messageHandler)   
            where T : class  
        {
            var channel = _connection.CreateModel();  
            channel.BasicQos(0, 1, false); // ??
  
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
                    var contentString = Encoding.UTF8.GetString(eArgs.Body);

                    // received message  
                    var content = !string.IsNullOrEmpty(contentString)
                        ? JsonConvert.DeserializeObject<T>(contentString)
                        : null;

                    // handle the received message  
                    messageHandler(content);

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

                _channels.Add(channel);
            }  
            catch (Exception ex)  
            {  
                channel.Close();
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
            _channels.ForEach(x => x.Close());
            _connection?.Close();
            base.Dispose();
        }

        #endregion
    }
}