using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _PaymentService;

        public PaymentController(IPaymentService PaymentService)
        {
            _PaymentService = PaymentService;
        }

        [HttpPost("customerPayment")]
        public async Task<IActionResult> CreatePaymentForCustomer(int customerId, decimal amount)
        {
            await _PaymentService.AddPaymentForCustomer(customerId, amount);
            return Ok("success");

        }

        [HttpPost("orderPayment")]
        public async Task<IActionResult> CreatePaymentForOrder(int orderId, decimal amount)
        {
           var result= await _PaymentService.ProcessPaymentAsync(orderId, amount);
            return Ok(result);

        }



        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetPaymentList( )
        //{
        //    IEnumerable<PaymentResponseDto> results = await _PaymentService.GetPaymentList();
        //    return Ok(results);

        //}

        //[HttpPost("GetById")]
        //public async Task<IActionResult> GitById(int id)
        //{
        //    var Payment = await _PaymentService.GetPaymentById(id);

        //    return Ok(Payment);

        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeletePayment(int PaymentId)
        //{
        //    PaymentResponseDto Payment = await _PaymentService.DeletePayment(PaymentId);
        //    return Ok(Payment);
        //}

        //[HttpPost("Edit")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var Measurements = await _unitOfWork.MeasurementRepository.GetFirstOrDefault(x => x.MeasurementID == id);
        //    if (Measurements == null)
        //    {
        //        return NotFound("There is no on by this GarmentId.");
        //    }
        //    await _unitOfWork.MeasurementRepository.Update(Measurements);

        //    return Ok(Measurements);

        //}





    }
}
