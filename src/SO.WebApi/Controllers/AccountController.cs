using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SO.Domain.UseCases.Account.Interfaces;
using SO.Domain.UseCases.Account.Models;

namespace SO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("create-account")]
        public async Task<IActionResult> CreateAccount(UserAccountModel accountModel)
        {
            var creationResult = await _accountService.CreateUserAccount(accountModel);

            if (!creationResult.IsSucceeded)
                return BadRequest(creationResult.Message);

            return Ok();
        }
    }
}