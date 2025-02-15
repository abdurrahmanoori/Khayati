using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Areas.Admin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }


        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers( )
        {
            var customers = await customerService.GetCustomerList();
            return Ok(
                customers.Select(x => new
                {
                    Id = x.CustomerId,
                    Name = x.Name
                })
            );


        }
    }
}
