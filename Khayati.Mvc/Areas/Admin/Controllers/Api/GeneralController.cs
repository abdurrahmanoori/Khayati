using Entities.Enum;
using Khayati.Core.Enums;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Areas.Admin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public GeneralController(ICustomerService customerService)
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

      

        [HttpGet("getPaymentStatus")]
        public IActionResult GetPaymentStatus( )
        {
            var paymentStatus = Enum.GetValues(typeof(PaymentStatus))
                                 .Cast<PaymentStatus>()
                                 .ToDictionary(e => (int)e, e => e.ToString());

            return Ok(paymentStatus);

        }
    }
}