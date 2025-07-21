using Khayati.Core.DTO;
using Khayati.Core.DTO.Customers;
using Khayati.Core.DTO.Orders;
using Khayati.Core.DTO.Payment;
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
        public async Task<ActionResult<OrderDto>> Create(OrderDto orderDto) =>
            HandleResultResponse(await _orderService.AddOrderWithDetails(orderDto));

        [HttpGet("/api/customers/{customerId}/orders")]
        public async Task<ActionResult<IEnumerable<CustomerOrderResponseDto>>> GetCustomerOrders(int customerId) =>
                   HandleResultResponse(await _orderService.GetOrdersByCustomerId(customerId));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders( ) =>
                   HandleResultResponse(await _orderService.GetOrders());
        [HttpGet("mock-orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders1( )
        {
            var mockOrders = new List<OrderDto>
               {
            new OrderDto
            {
                OrderId = 101,
                CustomerId = 501,
                ExpectedCompletionDate = DateTime.Parse("2025-07-15"),
                Cost = 120.00m,
                TotalCost = 150.00m,
                OrderDate = DateTime.Parse("2025-06-22T10:30:00"),
                IsPaid = false,
               
                Payments = new List<PaymentDto>
                {
                    new PaymentDto
                    {
                        Amount = 50.00m,
                        PaymentDate = DateTime.Parse("2025-06-22T11:00:00"),
                        OrderId = 101
                    }
                }
            }
    };

            return Ok(mockOrders);
        }




        [HttpGet("total-cost{orderId}")]
        public async Task<ActionResult<decimal?>> GetTotalCost(int orderId) =>
                 HandleResultResponse(await _orderService.CalculateTotalCost(orderId));

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrdersResponseDto>>> GetAllOrders() =>
        //    HandleResultResponse(await _orderService.GetAllOrders());

        [HttpDelete("id")]
        public async Task<ActionResult<bool>> Delete(int Id) => HandleResultResponse(await _orderService.DeleteOrder(Id));

        //[HttpPut("id")]

        //public async Task<ActionResult<bool>> Update(int Id, [FromBody]OrdersAddDto dto)=>
        
        //    HandleResultResponse(await _orderService.UpdateOrder(Id, dto));


    }
}