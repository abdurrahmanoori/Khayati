using Khayati.ServiceContracts.DTO;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentmentController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmbellishmentmentService _EmbellishmentmentService;

        public EmbellishmentmentController(IEmbellishmentmentService EmbellishmentmentService)
        {
            _EmbellishmentmentService = EmbellishmentmentService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(EmbellishmentmentAddDto addEmbellishmentmentDto)
        {
            var result = await _EmbellishmentmentService.AddEmbellishmentment(addEmbellishmentmentDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmbellishmentmentList()
        {
            IEnumerable<EmbellishmentmentResponseDto> results = await _EmbellishmentmentService.GetEmbellishmentmentList();
            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Embellishmentment = await _EmbellishmentmentService.GetEmbellishmentmentById(id);

            return Ok(Embellishmentment);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishmentment(int EmbellishmentmentId)
        {
            EmbellishmentmentResponseDto Embellishmentment = await _EmbellishmentmentService.DeleteEmbellishmentment(EmbellishmentmentId);
            return Ok(Embellishmentment);
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