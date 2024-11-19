using Khayati.Core.DTO;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmbellishmentService _EmbellishmentService;

        public EmbellishmentController(IEmbellishmentService EmbellishmentService)
        {
            _EmbellishmentService = EmbellishmentService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(EmbellishmentAddDto addEmbellishmentDto)
        {
            var result = await _EmbellishmentService.AddEmbellishment(addEmbellishmentDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmbellishmentList()
        {
            IEnumerable<EmbellishmentResponseDto> results = 
                await _EmbellishmentService
                .GetEmbellishmentList();

            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Embellishment = await _EmbellishmentService.GetEmbellishmentById(id);

            return Ok(Embellishment);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishment(int EmbellishmentId)
        {
            EmbellishmentResponseDto Embellishment = await _EmbellishmentService.DeleteEmbellishment(EmbellishmentId);
            return Ok(Embellishment);
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