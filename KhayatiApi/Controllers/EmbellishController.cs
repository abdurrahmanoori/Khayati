using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Base;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmbellishController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(Embellish Embellish)
        {
          await  _unitOfWork.EmbellishRepository.Add(Embellish);

          await  _unitOfWork.SaveChanges(CancellationToken.None);
            return Ok("susclrrry stored");

        }

        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmbellishList()
        {
            var result = await _unitOfWork.EmbellishRepository.GetAll();
            return Ok(result);

        }
        
        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id )
        {
            var Embellish = await _unitOfWork.EmbellishRepository.GetFirstOrDefault(x=>x.EmbellishId==id);
            if (Embellish == null)
            {
                return NotFound("There is no on by this Id.");
            }
            else
                return Ok(Embellish);

        }

        [HttpPost("Api/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var Measurement = await _unitOfWork.MeasurementRepository.GetFirstOrDefault(x => x.MeasurementID == id);
            if (Measurement == null)
            {
                return NotFound("There is no on by this Id.");
            }
            await _unitOfWork.MeasurementRepository.Update(Measurement);

            return Ok(Measurement);

        }





    }
}
