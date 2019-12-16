using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SO.Domain.Entities;
using SO.Domain.UseCases._Base.Models.PostResults;
using SO.Domain.UseCases.Identity.Interfaces;
using SO.Domain.UseCases.Identity.Models;
using SO.Domain.UseCases.Identity.Models.PostResults;

namespace SO.Domain.UseCases.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly PostResultFactory _postResultFactory;

        public IdentityService(
            UserManager<User> userManager, 
            PostResultFactory postResultFactory)
        {
            _userManager = userManager;
            _postResultFactory = postResultFactory;
        }

        public async Task<UserSavedResult> CreateUser(CreateUserModel model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.UserName);

            if (existingUser != null)
                return _postResultFactory.Error<UserSavedResult>(
                    $"User with UserName '{model.UserName}' already exists");

            var newUser = new User
            {
                UserName = model.UserName
            };

            var creationResult = await _userManager.CreateAsync(newUser, model.Password);

            if (creationResult.Succeeded)
            {
                return _postResultFactory.Success<UserSavedResult>(additionalSetup: x => x.UserId = newUser.Id);
            }
            else
            {
                return _postResultFactory.Error<UserSavedResult>(string.Join(", ",
                    creationResult.Errors.Select(x => x.Description)));
            }
        }
    }
}