using System.Threading.Tasks;
using SO.Domain.UseCases.Identity.Models;
using SO.Domain.UseCases.Identity.Models.PostResults;

namespace SO.Domain.UseCases.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<UserSavedResult> CreateUser(CreateUserModel model);
    }
}