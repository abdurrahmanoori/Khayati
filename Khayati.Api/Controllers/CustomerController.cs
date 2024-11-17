using Khayati.Core.DTO;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerAddDto addCustomerDto)
        {
            var result = await _customerService.AddCustomer(addCustomerDto);
            return Ok(result);

        }



        [HttpGet("GetAll")]
        public async Task<IActionResult> GetCustomerList()
        {
            IEnumerable<CustomerResponseDto> results =await _customerService.GetCustomerList();
            return Ok(results);

        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            return Ok(customer);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            CustomerResponseDto customer = await _customerService.DeleteCustomer(customerId);
            return Ok(customer);
        }

        //[HttpPost("Edit")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var Measurement = await _unitOfWork.MeasurementRepository.GetFirstOrDefault(x => x.MeasurementID == id);
        //    if (Measurement == null)
        //    {
        //        return NotFound("There is no on by this Id.");
        //    }
        //    await _unitOfWork.MeasurementRepository.Update(Measurement);

        //    return Ok(Measurement);

        //}





    }
}
