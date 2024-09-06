using Entities;
using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Base;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmblishTypeController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmblishTypeService _EmblishTypeService;

        public EmblishTypeController(IEmblishTypeService EmblishTypeService)
        {
            _EmblishTypeService = EmblishTypeService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(EmblishTypeAddDto addEmblishTypeDto)
        {
            var result = await _EmblishTypeService.AddEmblishType(addEmblishTypeDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmblishTypeList()
        {
            IEnumerable<EmblishTypeResponseDto> results =await _EmblishTypeService.GetEmblishTypeList();
            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var EmblishType = await _EmblishTypeService.GetEmblishTypeById(id);

            return Ok(EmblishType);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmblishType(int EmblishTypeId)
        {
            EmblishTypeResponseDto EmblishType = await _EmblishTypeService.DeleteEmblishType(EmblishTypeId);
            return Ok(EmblishType);
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
