using Khayati.Core.Domain.UserServiceContracts;
using System.Security.Claims;

namespace Khayati.Infrastructure.Repositories.UserServices
{
    public class CurrentUser : ICurrentUser
    {
        public Task<int?> GetUserId(ClaimsPrincipal user)
        {

            int? currentUserId = Convert.ToInt32(user?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (currentUserId is not null)
            {
                return Task.FromResult(currentUserId);
            }
            return null!; // Or handle appropriately when user ID is missing
        }
    }
}
