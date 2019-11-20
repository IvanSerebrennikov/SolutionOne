using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SO.Domain.UseCases.One.Interfaces;
using SO.Domain.UseCases.One.Models;

namespace SO.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OneController : ControllerBase
    {
        private readonly ILogger<OneController> _logger;
        private readonly IOneDataService _citiesDataService;

        public OneController(
            ILogger<OneController> logger,
            IOneDataService citiesDataService)
        {
            _logger = logger;
            _citiesDataService = citiesDataService;
        }

        [HttpGet]
        [Route("all-cities")]
        public IEnumerable<CityModel> GetAllCities()
        {
            return _citiesDataService.GetAllCities();
        }
    }
}