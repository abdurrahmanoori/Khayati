using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        [HttpGet("index1")]
        public IActionResult Index1()
        {
            return Ok("hello from api controller ");
        }

    }

   
}
