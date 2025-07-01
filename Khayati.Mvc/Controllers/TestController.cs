using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Core.DTO.Relative;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IEmbellishmentService _embellishment;
        private readonly ICustomerService _customerService;
        private readonly ICurrentUser _currentUser;
        private readonly HttpClient _httpClient;


        public TestController(IEmbellishmentService embellishment,
            ICustomerService customerService,
            ICurrentUser currentUser,
            IHttpClientFactory httpClientFactory)
        {
            _embellishment = embellishment;
            _customerService = customerService;
            _currentUser = currentUser;
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }


        [HttpGet("test")]
        public async Task<IActionResult> Get()
        {
            var response = await _httpClient.GetAsync("api/relative");
            if (response.IsSuccessStatusCode)
            {

                var data = await response.Content.ReadFromJsonAsync<List<RelativeDto>>();
                //return View(data);
            }

            //var cusotmer = _customerService.GetCustomerList();
            //var e = await _embellishment.GetEmbellishmentDetails(1);

            return Ok(_currentUser.GetUserId());
        }
    }
}
