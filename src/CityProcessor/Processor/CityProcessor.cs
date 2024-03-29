﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using AMQPSharedData.Messages;
using CityProcessor.HttpServices;
using CityProcessor.HttpServices.Models;
using CityProcessor.Hubs;
using CityProcessor.Hubs.Messages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace CityProcessor.Processor
{
    public class CityProcessor : ICityProcessor
    {
        private readonly ILogger<CityProcessor> _logger;

        private readonly IHubContext<CityProcessingHub, ICityProcessingClient> _hubContext;

        private readonly FakeExternalCityRegistryService _cityRegistryService;

        private readonly Random _random;

        public CityProcessor(
            ILogger<CityProcessor> logger,
            IHubContext<CityProcessingHub, ICityProcessingClient> hubContext,
            FakeExternalCityRegistryService cityRegistryService)
        {
            _logger = logger;
            _hubContext = hubContext;
            _cityRegistryService = cityRegistryService;
            _random = new Random();
        }

        public async Task ProcessCityCreated(CityCreatedMessage message)
        {
            if (message == null)
            {
                _logger.LogWarning("ProcessCityCreated: message is null.");
                return;
            }

            _logger.LogInformation(
                $"ProcessCityCreated: Message for City with Id {message.SolutionOneCityId} consumed!");

            var actionsGroupColor = GenerateRandomColor();

            await _hubContext.Clients.All.ReceiveCityProcessingMessage(
                CityClientMessage.CityCreatedMessageConsumed(message.SolutionOneCityId, message.Name, actionsGroupColor));

            string registryKey = null;
            try
            {
                await _hubContext.Clients.All.ReceiveCityProcessingMessage(
                    CityClientMessage.CityRegistrationRequested(message.SolutionOneCityId, message.Name, actionsGroupColor));

                registryKey = await _cityRegistryService.PostRegisterCity(new CityModel
                {
                    SolutionOneCityId = message.SolutionOneCityId,
                    Name = message.Name,
                    FoundationDate = message.FoundationDate
                });
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e,
                    "ProcessCityCreated: Http Exception during REST request to City Registry.");
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    "ProcessCityCreated: Unexpected Exception during REST request to City Registry.");
            }

            if (string.IsNullOrEmpty(registryKey))
            {
                _logger.LogWarning("ProcessCityCreated: Registry key is null.");
                return;
            }

            await _hubContext.Clients.All.ReceiveCityProcessingMessage(
                CityClientMessage.CityRegistrationCompleted(message.SolutionOneCityId, message.Name, registryKey, actionsGroupColor));

            // TODO: Produce CityRegisteredMessage to RabbitMQ
        }

        private string GenerateRandomColor()
        {
            return $"#{_random.Next(0x1000000):X6}";
        }
    }
}