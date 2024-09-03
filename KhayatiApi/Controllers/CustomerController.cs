using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Base;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(Customer customer)
        {
          await  _unitOfWork.CustomerRepository.Add(customer);

          await  _unitOfWork.SaveChanges(CancellationToken.None);
            return Ok("susclrrry stored");

        }

        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetCustomerList()
        {
            var result = await _unitOfWork.CustomerRepository.GetAll();
            return Ok(result);

        }
        
        [HttpPost("Api/GetById")]
        public async Task<IActionResult> Edit(int id )
        {
            var customer = await _unitOfWork.CustomerRepository.GetFirstOrDefault(x=>x.CustomerId==id);
            if (customer == null)
            {
                return NotFound("There is no on by this Id.");
            }
            else
                return Ok(customer);



            

        }




        
    }
}
