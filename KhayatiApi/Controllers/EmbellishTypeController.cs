using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Base;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmbellishTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(EmbellishType EmbellishType)
        {
          await  _unitOfWork.EmbellishTypeRepository.Add(EmbellishType);

          await  _unitOfWork.SaveChanges(CancellationToken.None);
            return Ok("susclrrry stored");

        }

        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmbellishTypeList()
        {
            var result = await _unitOfWork.EmbellishTypeRepository.GetAll();
            return Ok(result);

        }
        
        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id )
        {
            var EmbellishType = await _unitOfWork.EmbellishTypeRepository.GetFirstOrDefault(x=>x.EmbellishTypeId==id);
            if (EmbellishType == null)
            {
                return NotFound("There is no on by this Id.");
            }
            else
                return Ok(EmbellishType);

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
