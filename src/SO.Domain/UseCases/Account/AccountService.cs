using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SO.Domain.DataAccessInterfaces.Repository;
using SO.Domain.Entities;
using SO.Domain.Entities.Identity;
using SO.Domain.UseCases._Base.Models.PostResults;
using SO.Domain.UseCases.Account.Interfaces;
using SO.Domain.UseCases.Account.Models;
using SO.Domain.UseCases.Account.Models.PostResults;

namespace SO.Domain.UseCases.Account
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User, int> _usersRepository;
        private readonly UserManager<UserAccount> _accountsManager;
        private readonly PostResultFactory _postResultFactory;

        public AccountService(
            IRepository<User, int> usersRepository,
            UserManager<UserAccount> accountsManager,
            PostResultFactory postResultFactory)
        {
            _usersRepository = usersRepository;
            _accountsManager = accountsManager;
            _postResultFactory = postResultFactory;
        }

        public async Task<UserAccountCreatedResult> CreateUserAccount(UserAccountModel userAccountModel)
        {
            var account = new UserAccount
            {
                UserName = userAccountModel.UserName,
                Email = userAccountModel.Email
            };

            var result = await _accountsManager.CreateAsync(account, userAccountModel.Password);

            if (!result.Succeeded)
            {
                return _postResultFactory.Error<UserAccountCreatedResult>(
                    string.Join(", ",
                        result.Errors.Select(x => x.Description)));
            }

            var user = new User
            {
                AspNetUserId = account.Id
            };

            try
            {
                _usersRepository.Create(user);

                _usersRepository.Save();

                return _postResultFactory.Success<UserAccountCreatedResult>();
            }
            // TODO: catch custom DbSave exception
            catch (Exception e)
            {
                return _postResultFactory.Error<UserAccountCreatedResult>("Unexpected error", e);
            }
        }
    }
}