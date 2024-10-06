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

        public TestController(IEmbellishmentService embellishment, ICustomerService customerService)
        {
            _embellishment = embellishment;
            _customerService = customerService;
        }

        public async Task<IActionResult> Get()
        {
            var cusotmer = _customerService.GetCustomerList();
            var e = await _embellishment.GetEmbellishmentDetails(1);

            return Ok(e);
        }
    }
}
