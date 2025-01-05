using System.Security.Claims;

namespace Khayati.Core.Domain.UserServiceContracts
{
    public interface ICurrentUser
    {
        Task<int?> GetUserId(ClaimsPrincipal User);
    }
}
