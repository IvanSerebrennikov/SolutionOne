﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SO.Domain.Interfaces.DataServices;
using SO.Domain.Models;
using SO.IoC;

namespace SO.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OneController : ControllerBase
    {
        private readonly ILogger<OneController> _logger;
        private readonly ICitiesDataService _citiesDataService;

        public OneController(
            ILogger<OneController> logger)
        {
            _logger = logger;
            _citiesDataService = Container.GetCitiesDataService();
        }

        [HttpGet]
        [Route("cities")]
        public IEnumerable<CityModel> GetCities()
        {
            return _citiesDataService.GetCitiesByNames("CityOne", "CityTwo");
        }
    }
}