using Khayati.Core.DTO;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;
        private readonly IPaymentService _paymentService;
        //private readonly Fixture _fixture;


        public OrdersController(IOrdersService ordersService, IPaymentService paymentService)
        {
            _orderService = ordersService;
            //_fixture = new Fixture();
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdersAddDto ordersAddDto)
        {
            //var customer = DataGenerator.GenerateCustomer();
            //var measurment = DataGenerator.GenerateMeasurement();
            //var order = DataGenerator.GenerateOrder();

            var result = await _orderService.AddOrderWithDetails(ordersAddDto);

            return Ok(result);

        }

        [Route("/api/customers/{customerId}/orders")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            var result = await _orderService.GetOrdersByCustomerId(customerId);
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetTotalCost(int orderId)
        {
            var result = await _orderService.CalculateTotalCost(orderId);
            return Ok(result);
        }


        //[HttpGet("Api/GetAll")]
        //public async Task<IActionResult> GetOrdersList( )
        //{
        //    IEnumerable<OrdersResponseDto> results = await _OrdersService.GetOrdersList();
        //    return Ok(results);

        //}

        //[HttpPost("Api/GetById")]
        //public async Task<IActionResult> GitById(int id)
        //{
        //    var Orders = await _OrdersService.GetOrdersById(id);

        //    return Ok(Orders);

        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteOrders(int OrdersId)
        //{
        //    OrdersResponseDto Orders = await _OrdersService.DeleteOrders(OrdersId);
        //    return Ok(Orders);
        //}

        //        //[HttpPost("Api/Edit")]
        //        //public async Task<IActionResult> Edit(int id)
        //        //{
        //        //    var Orders = await _unitOfWork.OrderRepository.GetFirstOrDefault(x => x.OrdersId == id);
        //        //    if (Orders == null)
        //        //    {
        //        //        return NotFound("There is no on by this Id.");
        //        //    }
        //        //    await _unitOfWork.OrderRepository.Update(Orders);

        //        //    return Ok(Orders);

        //        //}






    }
}