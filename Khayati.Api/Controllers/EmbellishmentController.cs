using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentController : BaseApiController
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmbellishmentService _embellishmentService;

        public EmbellishmentController(IEmbellishmentService embellishmentService)
        {
            _embellishmentService = embellishmentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EmbellishmentAddDto addEmbellishmentDto)
        {
            var result = await _embellishmentService.AddEmbellishment(addEmbellishmentDto);
            return Ok(result);

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetEmbellishmentList( )
        {
            var results =
                await _embellishmentService
                .GetEmbellishmentList();

            return HandleResult(results);
        }

        [HttpPost("getById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Embellishment = await _embellishmentService.GetEmbellishmentById(id);

            return Ok(Embellishment);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishment(int EmbellishmentId)
        {
            EmbellishmentResponseDto Embellishment = await _embellishmentService.DeleteEmbellishment(EmbellishmentId);
            return Ok(Embellishment);
        }

        //[HttpPost("gdit")]
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