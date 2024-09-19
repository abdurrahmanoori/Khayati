using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMeasurementService _MeasurementService;

        public MeasurementController(IMeasurementService MeasurementService)
        {
            _MeasurementService = MeasurementService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(MeasurementAddDto addMeasurementDto)
        {
            var result = await _MeasurementService.AddMeasurement(addMeasurementDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetMeasurementList()
        {
            IEnumerable<MeasurementResponseDto> results =await _MeasurementService.GetMeasurementList();
            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Measurement = await _MeasurementService.GetMeasurementById(id);

            return Ok(Measurement);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMeasurement(int MeasurementId)
        {
            MeasurementResponseDto Measurement = await _MeasurementService.DeleteMeasurement(MeasurementId);
            return Ok(Measurement);
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
