using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SO.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OneController : ControllerBase
    {
        private readonly ILogger<OneController> _logger;

        public OneController(ILogger<OneController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return null;
        }
    }
}
