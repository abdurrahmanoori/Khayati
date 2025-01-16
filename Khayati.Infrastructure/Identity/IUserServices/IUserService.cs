using Khayati.Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;

namespace Khayati.Core.Domain.UserServiceContracts
{
    public interface IUserService
    {
        // User Management
        Task<IdentityResult> CreateUserAsync(string email, string password, string userName);
        Task<IdentityResult> UpdateUserAsync(string userId, string email, string userName);
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync( );

        // Authentication
        Task<bool> ValidateUserCredentialsAsync(string email, string password);
        //Task<string> GenerateJwtTokenAsync(ApplicationUser user);
        //Task SignInUserAsync(string email, string password, bool rememberMe);
        //Task SignOutAsync( );

        //// Password Management
        //Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        //Task<string> GeneratePasswordResetTokenAsync(string email);
        //Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);

        //// Role Management
        //Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName);
        //Task<IdentityResult> RemoveUserFromRoleAsync(string userId, string roleName);
        //Task<IList<string>> GetUserRolesAsync(string userId);
        //Task<IEnumerable<string>> GetAllRolesAsync( );
        //Task<bool> IsUserInRoleAsync(string userId, string roleName);

        //// Account Confirmation
        //Task<string> GenerateEmailConfirmationTokenAsync(string userId);
        //Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        //Task<bool> IsEmailConfirmedAsync(string userId);

        //// Two-Factor Authentication (Optional)
        //Task<IdentityResult> EnableTwoFactorAuthenticationAsync(string userId);
        //Task<IdentityResult> DisableTwoFactorAuthenticationAsync(string userId);
        //Task<string> GenerateTwoFactorTokenAsync(string userId, string provider);
        //Task<bool> VerifyTwoFactorTokenAsync(string userId, string provider, string token);

        //// Audit and Tracking
        //Task<IdentityResult> LockUserAccountAsync(string userId, DateTimeOffset? lockoutEnd);
        //Task<IdentityResult> UnlockUserAccountAsync(string userId);
        //Task<bool> IsUserLockedOutAsync(string userId);
        //Task UpdateLastLoginAsync(string userId);

        //// Claims Management
        //Task<IList<Claim>> GetUserClaimsAsync(string userId);
        //Task<IdentityResult> AddClaimToUserAsync(string userId, Claim claim);
        //Task<IdentityResult> RemoveClaimFromUserAsync(string userId, Claim claim);

        //// Utility Methods
        //Task<string> GenerateRandomPasswordAsync( );
    }
}
