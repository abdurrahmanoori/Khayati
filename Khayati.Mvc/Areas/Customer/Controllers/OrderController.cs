using Khayati.Core.Utility;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Khayati.Mvc.Areas.Customer.Controllers
{
    [Area(SD.Admin)]
    public class OrderController : Controller
    {
        private readonly IOrdersService _ordersService;

        public OrderController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
