using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AMQPSharedData;
using AMQPSharedData.Messages;
using CityProcessor.AppSettings;
using CityProcessor.Processor;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CityProcessor.ConsumerService
{
    public class RabbitMQConsumerService : BackgroundService
    {
        #region Fields

        private readonly ILogger<RabbitMQConsumerService> _logger;

        private readonly RabbitMQSettings _settings;

        private readonly ICityProcessor _cityProcessor;

        private IConnection _connection;

        private readonly List<IModel> _channels = new List<IModel>();

        private readonly List<Action> _consumers = new List<Action>();

        #endregion

        #region Ctor and RabbitMQ Init

        public RabbitMQConsumerService(
            ILogger<RabbitMQConsumerService> logger,
            IOptions<RabbitMQSettings> settings,
            ICityProcessor cityProcessor)
        {
            _logger = logger;
            _settings = settings.Value;
            _cityProcessor = cityProcessor;
            InitRabbitMQ();
            InitConsumers();
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

        private void InitConsumers()
        {
            _consumers.Add(ConsumeCityCreated);
        }

        private void ConsumeCityCreated()
        {
            Consume<CityCreatedMessage>(Queues.CityCreated,
                message =>
                {
                    _cityProcessor.ProcessCityCreated(message);
                });
        }

        #region Methods for internal usage

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _consumers.ForEach(x => x());
            
            return Task.CompletedTask;
        }

        private void Consume<T>(string queueName, Action<T> messageHandler)   
            where T : class  
        {
            var channel = _connection.CreateModel();  

            // don't dispatch a new message to a worker until it has processed and acknowledged the previous one
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
                    var contentString = Encoding.UTF8.GetString(eArgs.Body);

                    // received message  
                    var content = !string.IsNullOrEmpty(contentString)
                        ? JsonConvert.DeserializeObject<T>(contentString)
                        : null;

                    try
                    {
                        // handle the received message  
                        messageHandler(content);
                        
                        channel.BasicAck(eArgs.DeliveryTag, false);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e,
                            $"Unhandled exception during message processing for {typeof(T)}. " +
                            "Message is unacknowledged and stayed in Queue.");
                    }
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
            catch (Exception e)  
            {  
                _logger.LogError(e, $"Exception during consumer registration for {typeof(T)}");
                channel.Close();
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