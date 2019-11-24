﻿using AMQPSharedData.Messages;
using Microsoft.Extensions.Logging;

namespace CityProcessor.Processor
{
    public class CityProcessor : ICityProcessor
    {
        private readonly ILogger<CityProcessor> _logger;

        public CityProcessor(ILogger<CityProcessor> logger)
        {
            _logger = logger;
        }

        public void ProcessCityCreated(CityCreatedMessage message)
        {
            _logger.LogDebug($"City with Id {message.SolutionOneCityId} created!");
        }
    }
}