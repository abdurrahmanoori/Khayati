using Entities;
using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Base;

namespace KhayatiApi.Controllers
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

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(CustomerAddDto addCustomerDto)
        {
            var result = await _customerService.AddCustomer(addCustomerDto);
            return Ok(result);

        }



        //[HttpGet("Api/GetAll")]
        //public async Task<IActionResult> GetCustomerList()
        //{
        //    var result = await _unitOfWork.CustomerRepository.GetAll();
        //    return Ok(result);

        //}

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);

            return Ok(customer);

        }

        //[HttpPost("Api/Edit")]
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
