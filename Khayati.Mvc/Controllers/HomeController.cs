using Khayati.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Khayati.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly ICustomerService _customerService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
          //  _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            object result = null;// await _customerService.GetCustomerList();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
