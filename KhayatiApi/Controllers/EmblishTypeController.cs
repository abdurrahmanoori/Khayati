using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentmentTypeController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmbellishmentmentTypeService _EmbellishmentmentTypeService;

        public EmbellishmentmentTypeController(IEmbellishmentmentTypeService EmbellishmentmentTypeService)
        {
            _EmbellishmentmentTypeService = EmbellishmentmentTypeService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(EmbellishmentmentTypeAddDto addEmbellishmentmentTypeDto)
        {
            var result = await _EmbellishmentmentTypeService.AddEmbellishmentmentType(addEmbellishmentmentTypeDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmbellishmentmentTypeList()
        {
            IEnumerable<EmbellishmentmentTypeResponseDto> results =await _EmbellishmentmentTypeService.GetEmbellishmentmentTypeList();
            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var EmbellishmentmentType = await _EmbellishmentmentTypeService.GetEmbellishmentmentTypeById(id);

            return Ok(EmbellishmentmentType);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishmentmentType(int EmbellishmentmentTypeId)
        {
            EmbellishmentmentTypeResponseDto EmbellishmentmentType = await _EmbellishmentmentTypeService.DeleteEmbellishmentmentType(EmbellishmentmentTypeId);
            return Ok(EmbellishmentmentType);
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
