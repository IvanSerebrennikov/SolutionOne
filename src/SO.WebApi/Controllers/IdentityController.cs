using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.Domain.Entities;
using SO.Domain.UseCases.Identity.Interfaces;
using SO.Domain.UseCases.Identity.Models;

namespace SO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(
            IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserModel model)
        {
            var creationResult = await _identityService.CreateUser(model);

            if (!creationResult.IsSucceeded)
                return BadRequest(creationResult.Message);

            return Ok(new {creationResult.UserId});
        }
    }
}