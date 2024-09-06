using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Base;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeasurementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(Measurement Measurement)
        {
            await _unitOfWork.MeasurementRepository.Add(Measurement);

            await _unitOfWork.SaveChanges(CancellationToken.None);
            return Ok("susclrrry stored");

        }

        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetMeasurementList()
        {
            var result = await _unitOfWork.MeasurementRepository.GetAll();
            return Ok(result);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var Measurement = await _unitOfWork.MeasurementRepository.GetFirstOrDefault(x => x.MeasurementID == id);
            if (Measurement == null)
            {
                return NotFound("There is no on by this Id.");
            }
            else
                return Ok(Measurement);

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
