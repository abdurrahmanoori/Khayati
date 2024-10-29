using AutoFixture;
using Khayati.Core.DTO;
using Khayati.Core.Utility;
using Khayati.Mvc.DataGenerators;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace Khayati.Mvc.Areas.Customer.Controllers
{
    [Area(SD.Admin)]
    public class OrderController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly Fixture _fixture;


        public OrderController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
            _fixture = new Fixture();
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create()
        {

            var customer = DataGenerator.GenerateCustomer();
            var measurment = DataGenerator.GenerateMeasurement();
            var order = DataGenerator.GenerateOrder();


            // Create an anonymous object to hold all the data you want to return as JSON
            var resultData = new
            {
                Customer = customer,
                Measurement = measurment,
                Order = order
            };
            

            // Return as JSON, automatically serialized by .NET
            return Ok(resultData); // or use `return Json(resultData);` if Ok() is not available
        }
    }
}
