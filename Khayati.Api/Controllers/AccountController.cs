using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Core.DTO;
using Khayati.Infrastructure.Identity.Entity;
using Khayati.Infrastructure.Identity.IdentityDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseApiController
    {
        private readonly IUserService _userService;
        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponseDto>> CreateUser(AuthRequestDto authRequestDto) =>
        HandleResultResponse(await _userService.CreateUserAsync(authRequestDto));

        [HttpGet]
        public async Task<ActionResult<ApplicationUser>> GetUserById(string? id)
        {

            var user = await _userService.GetUserByIdAsync(id);

            return default;
        }
        //[Authorize]
        [HttpGet("me")]
        public IActionResult GetUserProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var username = User.Identity?.Name;

            return Ok(new
            {
                UserId = userId,
                Email = email,
                UserName = username
            });
        }

    }
}
