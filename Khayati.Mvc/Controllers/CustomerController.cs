using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            

            var result = await _customerService.GetCustomerList();
            return View(result);
        }
    }
}
