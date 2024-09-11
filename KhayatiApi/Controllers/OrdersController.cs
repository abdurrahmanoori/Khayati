using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KhayatiApi.Controllers
{
    public class OrdersController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IOrdersService _OrdersService;
        

        public OrdersController(IOrdersService OrdersService)
        {
            _OrdersService = OrdersService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(OrdersAddDto addOrdersDto)
        {
            var result = await _OrdersService.AddOrders(addOrdersDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetOrdersList()
        {
            IEnumerable<OrdersResponseDto> results = await _OrdersService.GetOrdersList();
            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Orders = await _OrdersService.GetOrdersById(id);

            return Ok(Orders);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrders(int OrdersId)
        {
            OrdersResponseDto Orders = await _OrdersService.DeleteOrders(OrdersId);
            return Ok(Orders);
        }

        //[HttpPost("Api/Edit")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var Orders = await _unitOfWork.OrderRepository.GetFirstOrDefault(x => x.OrdersId == id);
        //    if (Orders == null)
        //    {
        //        return NotFound("There is no on by this Id.");
        //    }
        //    await _unitOfWork.OrderRepository.Update(Orders);

        //    return Ok(Orders);

        //}





    }
}
