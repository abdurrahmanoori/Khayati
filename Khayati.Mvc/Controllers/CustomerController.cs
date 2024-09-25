using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Khayati.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        //private readonly ICustomerService _customerService;

        public CustomerController()
        {
            //_customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7235/");
            HttpResponseMessage res = await client.GetAsync("api/Customer/GetAll");
            if (!res.IsSuccessStatusCode)
            {
                return NotFound();
            }

          var result =  res.Content.ReadAsStringAsync().Result;
           var studentList =  JsonConvert.DeserializeObject<IEnumerable<CustomerResponseDto>>(result);


            // var result = await _customerService.GetCustomerList();
            return View(studentList);
        }
    }
}
