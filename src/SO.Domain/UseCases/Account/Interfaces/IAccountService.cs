using System.Threading.Tasks;
using SO.Domain.UseCases.Account.Models;
using SO.Domain.UseCases.Account.Models.PostResults;

namespace SO.Domain.UseCases.Account.Interfaces
{
    public interface IAccountService
    {
        Task<UserAccountCreatedResult> CreateUserAccount(UserAccountModel userAccountModel);
    }
}