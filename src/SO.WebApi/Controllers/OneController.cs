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
        private readonly IOneService _oneService;

        public OneController(
            ILogger<OneController> logger,
            IOneService oneService)
        {
            _logger = logger;
            _oneService = oneService;
        }

        [HttpGet]
        [Route("all-cities")]
        public IEnumerable<CityWithApartmentsCountModel> GetAllCities()
        {
            return _oneService.GetAllCities();
        }
    }
}