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
        public async Task<ActionResult<OrdersAddDto>> Create(OrdersAddDto ordersAddDto) =>
            HandleResultResponse(await _orderService.AddOrderWithDetails(ordersAddDto));

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
                AmountPaid = 50.00m,
                RemainingAmount = 100.00m,
                CustomerDto = new CustomerDto
                {
                    CustomerId = 501,
                    Name = "Ali",
                    LastName = "Rahimi",
                    Address = "No. 12, Street 5, Kabul",
                    Gender = "Male",
                    PhoneNumber = "+93 700 123 456",
                    EmailAddress = "ali.rahimi@example.com",
                    NationalID = "1234567890123",
                    DateOfBirth = DateTime.Parse("1990-03-15")
                },
                PaymentDtos = new List<PaymentDto>
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
        //        //        return NotFound("There is no on by this GarmentId.");
        //        //    }
        //        //    await _unitOfWork.OrderRepository.Update(Orders);

        //        //    return Ok(Orders);

        //        //}






    }
}