using System.Threading.Tasks;
using AMQPSharedData.Messages;
using CityProcessor.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace CityProcessor.Processor
{
    public class CityProcessor : ICityProcessor
    {
        private readonly ILogger<CityProcessor> _logger;

        private readonly IHubContext<CityProcessingHub, ICityProcessingClient> _hubContext;

        public CityProcessor(
            ILogger<CityProcessor> logger,
            IHubContext<CityProcessingHub, ICityProcessingClient> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task ProcessCityCreated(CityCreatedMessage message)
        {
            if (message == null)
            {
                _logger.LogWarning("ProcessCityCreated: message is null.");
                return;
            }

            // TODO: Generate unique color for all alerts for one message (on back or front)

            await _hubContext.Clients.All.ReceiveCityProcessingMessage(
                ClientMessages.GetCityCreatedMessageConsumed(message.SolutionOneCityId, message.Name));

            // TODO: Send REST Request to FakeExternalCityRegistry

            // TODO: Get Response from FakeExternalCityRegistry

            // TODO: Produce CityRegisteredMessage to RabbitMQ

            _logger.LogInformation(
                $"ProcessCityCreated: Message for City with Id {message.SolutionOneCityId} consumed!");
        }
    }
}