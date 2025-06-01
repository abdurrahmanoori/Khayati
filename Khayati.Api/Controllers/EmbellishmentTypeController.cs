using Khayati.Core.DTO.EmbellishmentType;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmbellishmentTypeController : BaseApiController
    {
        private readonly IEmbellishmentTypeService _embellishmentTypeService;

        public EmbellishmentTypeController(IEmbellishmentTypeService embellishmentTypeService)
        {
            _embellishmentTypeService = embellishmentTypeService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EmbellishmentTypeAddDto addEmbellishmentTypeDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _embellishmentTypeService.AddEmbellishmentType(addEmbellishmentTypeDto);
            return Ok(result);

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetEmbellishmentTypeList()
        {
            IEnumerable<EmbellishmentTypeResponseDto> results =await _embellishmentTypeService.GetEmbellishmentTypeList();
            return Ok(results);

        }

        [HttpPost("getById")]
        public async Task<IActionResult> GitById(int id)
        {
            var EmbellishmentType = await _embellishmentTypeService.GetEmbellishmentTypeById(id);

            return Ok(EmbellishmentType);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishmentType(int EmbellishmentTypeId)
        {
            EmbellishmentTypeResponseDto EmbellishmentType = await _embellishmentTypeService.DeleteEmbellishmentType(EmbellishmentTypeId);
            return Ok(EmbellishmentType);
        }

        //[HttpPost("gdit")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var Measurements = await _unitOfWork.MeasurementRepository.GetFirstOrDefault(x => x.MeasurementID == id);
        //    if (Measurements == null)
        //    {
        //        return NotFound("There is no on by this Id.");
        //    }
        //    await _unitOfWork.MeasurementRepository.Update(Measurements);

        //    return Ok(Measurements);

        //}





    }
}
