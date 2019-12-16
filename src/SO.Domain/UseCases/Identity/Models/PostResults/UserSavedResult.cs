using SO.Domain.UseCases._Base.Models.PostResults;

namespace SO.Domain.UseCases.Identity.Models.PostResults
{
    public class UserSavedResult : PostResultBase
    {
        public int UserId { get; internal set; }
    }
}