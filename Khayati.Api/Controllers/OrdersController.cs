//using Khayati.Core.DTO;
//using Khayati.ServiceContracts;
//using Microsoft.AspNetCore.Mvc;
using Khayati.Core.DTO;
using Khayati.Mvc.DataGenerators;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
namespace Khayati.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IPaymentService _paymentService;
        //private readonly Fixture _fixture;


        public OrdersController(IOrdersService ordersService, IPaymentService paymentService)
        {
            _ordersService = ordersService;
            //_fixture = new Fixture();
            _paymentService = paymentService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(OrdersAddDto addOrdersDto)
        {

            var customer = DataGenerator.GenerateCustomer();
            var measurment = DataGenerator.GenerateMeasurement();
            var order = DataGenerator.GenerateOrder();

            var result = await _ordersService.AddOrderWithDetails(customer, measurment, order);

            return Ok(result);




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
}