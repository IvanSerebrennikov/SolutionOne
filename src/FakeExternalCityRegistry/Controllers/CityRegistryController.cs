using System;
using System.Threading;
using FakeExternalCityRegistry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeExternalCityRegistry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityRegistryController : ControllerBase
    {
        private readonly ILogger<CityRegistryController> _logger;

        public CityRegistryController(ILogger<CityRegistryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "FakeExternalCityRegistry API.";
        }

        [HttpPost]
        [Route("register-city")]
        public string RegisterCity(CityModel cityModel)
        {
            // Fake 5 sec long operation...
            Thread.Sleep(5000);

            // Fake Registry City Id
            var registryCityId = Guid.NewGuid().ToString();

            return registryCityId;
        }
    }
}