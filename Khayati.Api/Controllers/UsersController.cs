using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Core.DTO;
using Khayati.Infrastructure.Identity.IdentityDTO;
using Khayati.Infrastructure.Identity.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponseDto>> createUser(UserDto userDto)=>
        HandleResultResponse(await _userService.CreateUserAsync(userDto));
        
    }
}
