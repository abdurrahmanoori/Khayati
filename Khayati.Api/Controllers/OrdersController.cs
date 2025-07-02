using Khayati.Core.DTO;
using Khayati.Core.DTO.Orders;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrdersController : BaseApiController
    {
        private readonly IOrdersService _orderService;
        private readonly IPaymentService _paymentService;


        public OrdersController(IOrdersService ordersService, IPaymentService paymentService)
        {
            _orderService = ordersService;
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<ActionResult<OrdersAddDto>> Create(OrdersAddDto ordersAddDto) =>
            HandleResultResponse(await _orderService.AddOrderWithDetails(ordersAddDto));

        [HttpGet("/api/customers/{customerId}/orders")]
        public async Task<ActionResult<IEnumerable<CustomerOrderResponseDto>>> GetCustomerOrders(int customerId) =>
                   HandleResultResponse(await _orderService.GetOrdersByCustomerId(customerId));


        [HttpGet("total-cost{orderId}")]
        public async Task<ActionResult<decimal?>> GetTotalCost(int orderId) =>
                 HandleResultResponse(await _orderService.CalculateTotalCost(orderId));


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