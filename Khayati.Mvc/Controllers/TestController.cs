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

        public TestController(IEmbellishmentService embellishment)
        {
            _embellishment = embellishment;
        }

        public async Task<IActionResult> Get()
        {
            var r =await _embellishment.GetEmbellishmentList();

            //await _embellishment.GetEmbellishmentDetails();

            return Ok(r);
        }
    }
}
