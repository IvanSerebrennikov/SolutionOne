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

        [HttpPost]
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