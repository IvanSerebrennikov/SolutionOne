using Microsoft.AspNetCore.Mvc;
using SO.Domain.UseCases.Admin.Interfaces;
using SO.Domain.UseCases.Admin.Models;
using SO.WebApi.ActionResults;

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
        public DefaultActionResult CreateCity(CityModel cityModel)
        {
            var creationResult = _adminService.CreateCity(cityModel);

            return creationResult.IsSucceeded
                ? DefaultActionResult.Ok(creationResult.Message, new {creationResult.CityId})
                : DefaultActionResult.BadResult(creationResult.Message);
        }
    }
}