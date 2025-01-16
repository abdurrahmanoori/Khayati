using Khayati.Core.DTO;
using Khayati.Core.DTO.EmbellishmentType;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentTypeController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmbellishmentTypeService _EmbellishmentTypeService;

        public EmbellishmentTypeController(IEmbellishmentTypeService EmbellishmentTypeService)
        {
            _EmbellishmentTypeService = EmbellishmentTypeService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(EmbellishmentTypeAddDto addEmbellishmentTypeDto)
        {
            var result = await _EmbellishmentTypeService.AddEmbellishmentType(addEmbellishmentTypeDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmbellishmentTypeList()
        {
            IEnumerable<EmbellishmentTypeResponseDto> results =await _EmbellishmentTypeService.GetEmbellishmentTypeList();
            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var EmbellishmentType = await _EmbellishmentTypeService.GetEmbellishmentTypeById(id);

            return Ok(EmbellishmentType);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishmentType(int EmbellishmentTypeId)
        {
            EmbellishmentTypeResponseDto EmbellishmentType = await _EmbellishmentTypeService.DeleteEmbellishmentType(EmbellishmentTypeId);
            return Ok(EmbellishmentType);
        }

        //[HttpPost("Api/Edit")]
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
