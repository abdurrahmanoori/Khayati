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
        [HttpGet]
        public IActionResult GetCustomers([FromQuery] string? search = "", [FromQuery] int limit = 10)
        {
            var customers = AllCustomers
                .Where(c => string.IsNullOrEmpty(search) || c.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                .Take(limit)
                .ToList();

            return Ok(customers);
        }



        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private static List<Customer> AllCustomers = new List<Customer>
         {
             new Customer { Id = 1, Name = "John Doe" },
             new Customer { Id = 2, Name = "Jane Smith" },
             new Customer { Id = 3, Name = "Alice Johnson" },
             new Customer { Id = 4, Name = "Michael Brown" },
             new Customer { Id = 5, Name = "Emily Davis" },
             new Customer { Id = 6, Name = "Chris Wilson" },
             new Customer { Id = 7, Name = "Jessica Moore" },
             new Customer { Id = 8, Name = "David Clark" },
             new Customer { Id = 9, Name = "Laura Allen" },
             new Customer { Id = 10, Name = "James White" },
             new Customer { Id = 11, Name = "Robert Hall" },
             new Customer { Id = 12, Name = "Sarah Lewis" }
         };
        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers( )
        {
            var customers = await customerService.GetCustomerList();
            return Ok(
                customers.Response.Select(x => new
                {
                    Id = x.CustomerId,
                    Name = x.Name
                })
            );


        }

        [HttpGet("Priorities")]
        public IActionResult GetPriorities( )
        {
            var priorities = Enum.GetValues(typeof(OrderPriority))
                                 .Cast<OrderPriority>()
                                 .ToDictionary(e => (int)e, e => e.ToString());
            var prioritiesList = priorities.Select(x => new
            {
                Id = x.Key,
                Name = x.Value
            });

            return Ok(prioritiesList);
        }
        [HttpGet("orderStatuses")]
        public IActionResult GetOrderStatuses( )
        {
            var orderStatusesList = Enum.GetValues<OrderStatus>()
                .Select(status => new { Id = status, Name = status.ToString() });

            return Ok(orderStatusesList);
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