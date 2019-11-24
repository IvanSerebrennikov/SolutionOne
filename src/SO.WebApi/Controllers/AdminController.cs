using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SO.Domain.UseCases.Admin.Interfaces;
using SO.Domain.UseCases.Admin.Models;

namespace SO.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(
            IAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// create new city
        /// </summary>
        /// <param name="cityModel">new city model</param>
        /// <returns>object with newly created city Id</returns>
        /// <response code="200">Returns object with newly created city Id</response>
        /// <response code="400">Returns error message if smth goes wrong and city was not created</response>       
        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Route("create-city")]
        public IActionResult CreateCity(CityModel cityModel)
        {
            var creationResult = _adminService.CreateCity(cityModel);

            if (!creationResult.IsSucceeded)
                return BadRequest(creationResult.Message);

            return Ok(new {creationResult.CityId});
        }
    }
}