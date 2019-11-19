using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SO.Domain.UseCases.One.Interfaces;
using SO.Domain.UseCases.One.Models;
using SO.IoC;

namespace SO.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OneController : ControllerBase
    {
        private readonly ILogger<OneController> _logger;
        private readonly IOneDataService _citiesDataService;

        public OneController(
            ILogger<OneController> logger)
        {
            _logger = logger;
            _citiesDataService = Container.GetCitiesDataService();
        }

        [HttpGet]
        [Route("all-cities")]
        public IEnumerable<CityModel> GetAllCities()
        {
            return _citiesDataService.GetAllCities();
        }
    }
}