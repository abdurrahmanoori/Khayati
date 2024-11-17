using Khayati.Core.Domain.UserServiceContracts;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEmbellishmentService _embellishment;
        private readonly ICustomerService _customerService;
        private readonly ICurrentUser _currentUser;


        public TestController(IEmbellishmentService embellishment, ICustomerService customerService, ICurrentUser currentUser)
        {
            _embellishment = embellishment;
            _customerService = customerService;
            _currentUser = currentUser;
        }
        [HttpGet("test")]
        public async Task<IActionResult> Get()
        {

            //var cusotmer = _customerService.GetCustomerList();
            //var e = await _embellishment.GetEmbellishmentDetails(1);

            return Ok(await _currentUser.GetUserId(User));
        }
    }
}
