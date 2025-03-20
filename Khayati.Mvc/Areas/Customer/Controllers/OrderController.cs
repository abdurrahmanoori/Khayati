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
        private readonly IPaymentService _paymentService;
        private readonly Fixture _fixture;


        public OrderController(IOrdersService ordersService, IPaymentService paymentService)
        {
            _ordersService = ordersService;
            _fixture = new Fixture();
            _paymentService = paymentService;
        }

        public async Task<IActionResult> Index(int orderId)
        {
            var tototalCost = await _ordersService.CalculateTotalCost(orderId);
            return Ok(new { TotalCost = tototalCost });
        }

        public async Task<IActionResult> Payment(int orderId, decimal amount)
        {
            await _paymentService.ProcessPaymentAsync(orderId, amount);
            return Ok();
        }


        public async Task<IActionResult> Create( )
        {

            var customer = DataGenerator.GenerateCustomer();
            var measurment = DataGenerator.GenerateMeasurement();
            var order = DataGenerator.GenerateOrder();

            //var result = await _ordersService.AddOrderWithDetails(customer, measurment, order);

            return Ok();
            //// Create an anonymous object to hold all the data you want to return as JSON
            //var resultData = new
            //{
            //    Customer = customer,
            //    Measurements = measurment,
            //    Order = order
            //};


            // Return as JSON, automatically serialized by .NET
            // return Ok(resultData); // or use `return Json(resultData);` if Ok() is not available
        }
    }
}
