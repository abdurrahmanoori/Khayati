using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Khayati.Core.Common.Response;
using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Core.DTO;
using Khayati.Infrastructure.Identity.Entity;
using Khayati.Infrastructure.Identity.IdentityDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.Extensions.Configuration;

namespace Khayati.Infrastructure.Identity.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _configuration;
        //private readonly ILogger<UserService> _logger;
        //private readonly string _jwtSecret;

        public UserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IOptions<JwtSettings> jwtOptions            /*ILogger<UserService> logger,
                        string jwtSecret*/
                                          ,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtSettings = jwtOptions.Value;
            _configuration = configuration;
            //_logger = logger;
            //_jwtSecret = jwtSecret;
        }

        public async Task<Result<AuthResponseDto>> CreateUserAsync(AuthRequestDto dto)
        {
            var user = new ApplicationUser
            {
                Email = dto.Email,
                UserName = dto.UserName,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .Select(e => new ValidationError { Code = e.Code, Description = e.Description })
                    .ToList();

                return Result<AuthResponseDto>.WithErrors(errors);
            }

            // Optionally add claims or roles here
            // await _userManager.AddToRoleAsync(user, "User");

            var token = await GenerateJwtToken(user);

            var response = new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = token
            };

            return Result<AuthResponseDto>.SuccessResult(response);
        }

        public async Task<Result<bool>> UpdateUserAsync(string userId, AuthRequestDto authRequestDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return Result<bool>.WithError(new ValidationError { Description = "User not found" });

            user.Email = authRequestDto.Email;
            user.UserName = authRequestDto.UserName;
            IdentityResult result = await _userManager.UpdateAsync(user);
            var errors = !result.Succeeded ? result.Errors
    .Select(e => new ValidationError { Code = e.Code, Description = e.Description })
    .ToList() : [];
            return result.Succeeded ? Result<bool>.SuccessResult(true) : Result<bool>.WithErrors(errors);
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user != null ? await _userManager.DeleteAsync(user) : IdentityResult.Failed(new IdentityError { Description = "User not found" });
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId) => await _userManager.FindByIdAsync(userId);

        public async Task<ApplicationUser> GetUserByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync() => await _userManager.Users.ToListAsync();

        // Authentication
        public async Task<bool> ValidateUserCredentialsAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);
            return user != null && await _userManager.CheckPasswordAsync(user, password);
        }

        Task<Result<bool>> IUserService.DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }





        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var jwtSetting = _configuration.GetSection("JwtSettings").Get<JwtSettings>();
            // Add user roles (if applicable)
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting!.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //public async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.GarmentId),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };

        //    var roles = await _userManager.GetRolesAsync(user);
        //    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: "YourIssuer",
        //        audience: "YourAudience",
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddHours(1),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //public async Task SignInUserAsync(string email, string password, bool rememberMe)
        //{
        //    var user = await GetUserByEmailAsync(email);
        //    if (user == null) throw new Exception("Invalid login attempt.");

        //    var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
        //    if (!result.Succeeded) throw new Exception("Invalid login attempt.");
        //}

        //public async Task SignOutAsync( ) => await _signInManager.SignOutAsync();

        //// Password Management
        //public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        //}

        //public async Task<string> GeneratePasswordResetTokenAsync(string email)
        //{
        //    var user = await GetUserByEmailAsync(email);
        //    return user != null ? await _userManager.GeneratePasswordResetTokenAsync(user) : null;
        //}

        //public async Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.ResetPasswordAsync(user, token, newPassword) : IdentityResult.Failed();
        //}

        //// Role Management
        //public async Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.AddToRoleAsync(user, roleName) : IdentityResult.Failed();
        //}

        //public async Task<IdentityResult> RemoveUserFromRoleAsync(string userId, string roleName)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.RemoveFromRoleAsync(user, roleName) : IdentityResult.Failed();
        //}

        //public async Task<IList<string>> GetUserRolesAsync(string userId)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.GetRolesAsync(user) : new List<string>();
        //}

        //public async Task<IEnumerable<string>> GetAllRolesAsync( ) => _roleManager.Roles.Select(r => r.Name).ToList();

        //public async Task<bool> IsUserInRoleAsync(string userId, string roleName)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null && await _userManager.IsInRoleAsync(user, roleName);
        //}

        //// Account Confirmation
        //public async Task<string> GenerateEmailConfirmationTokenAsync(string userId)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.GenerateEmailConfirmationTokenAsync(user) : null;
        //}

        //public async Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.ConfirmEmailAsync(user, token) : IdentityResult.Failed();
        //}

        //public async Task<bool> IsEmailConfirmedAsync(string userId)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null && await _userManager.IsEmailConfirmedAsync(user);
        //}

        //// Audit and Tracking
        //public async Task<IdentityResult> LockUserAccountAsync(string userId, DateTimeOffset? lockoutEnd)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.SetLockoutEndDateAsync(user, lockoutEnd) : IdentityResult.Failed();
        //}

        //public async Task<IdentityResult> UnlockUserAccountAsync(string userId)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.SetLockoutEndDateAsync(user, null) : IdentityResult.Failed();
        //}

        //public async Task<bool> IsUserLockedOutAsync(string userId)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null && await _userManager.IsLockedOutAsync(user);
        //}

        //public async Task UpdateLastLoginAsync(string userId)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    if (user != null)
        //    {
        //        user.LastLoginDate = DateTime.UtcNow;
        //        await _userManager.UpdateAsync(user);
        //    }
        //}

        // Claims Management
        //public async Task<IList<Claim>> GetUserClaimsAsync(string userId)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.GetClaimsAsync(user) : new List<Claim>();
        //}

        //public async Task<IdentityResult> AddClaimToUserAsync(string userId, Claim claim)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.AddClaimAsync(user, claim) : IdentityResult.Failed();
        //}

        //public async Task<IdentityResult> RemoveClaimFromUserAsync(string userId, Claim claim)
        //{
        //    var user = await GetUserByIdAsync(userId);
        //    return user != null ? await _userManager.RemoveClaimAsync(user, claim) : IdentityResult.Failed();
        //}

        //// Utility Methods
        //public Task<string> GenerateRandomPasswordAsync( )
        //{
        //    return Task.FromResult(Guid.NewGuid().ToString("N").Substring(0, 12));
        //}
    }
}
