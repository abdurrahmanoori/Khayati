using Khayati.Core.DTO;
using Khayati.Core.DTO.Customers;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(CustomerAddDto dto) =>
         HandleResultResponse(await _customerService.AddCustomer(dto));

        [HttpGet]
        public async Task<ActionResult<List<CustomerResponseDto>>> GetAll( ) =>
            HandleResultResponse(await _customerService.GetCustomerList());

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetById(int id) =>
            HandleResultResponse(await _customerService.GetCustomerById(id));

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, CustomerDto dto) =>    
            HandleResultResponse(await _customerService.UpdateCustomer(id, dto));

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id) =>
            HandleResultResponse(await _customerService.DeleteCustomer(id));
    }
}
