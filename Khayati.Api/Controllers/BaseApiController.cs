using Khayati.Core.Common.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public IActionResult HandleResult<T>(Result<T> response)
        {
            try
            {
                if (response.Success && response.Response == null)
                {
                    return NotFound();
                }
                else if (response.Success && response.Response != null)
                {
                    return Ok(response.Response);
                }
                else if (!response.Success && response.Errors != null)
                {
                    return BadRequest(response.Errors);
                }
                //// If the list of entites is empty
                //else if (!response.Success && response.Message != null)
                //{
                //    return BadRequest(response.Message);
                //}
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public ActionResult<T> HandleResultResponse<T>(Result<T> response)
        {
            try
            {
                if (response.Success && response.Response == null)
                {
                    return NotFound();
                }
                else if (response.Success && response.Response != null)
                {
                    return Ok(response.Response);
                }
                else if (!response.Success && response.Errors != null)
                {
                    return BadRequest(response.Errors);
                }
                //// If the list of entites is empty
                //else if (!response.Success && response.Message != null)
                //{
                //    return BadRequest(response.Message);
                //}
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
