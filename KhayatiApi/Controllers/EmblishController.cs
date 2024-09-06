using Khayati.ServiceContracts.DTO;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhayatiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmblishController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmblishService _EmblishService;

        public EmblishController(IEmblishService EmblishService)
        {
            _EmblishService = EmblishService;
        }

        [HttpPost("Api/Create")]
        public async Task<IActionResult> Create(EmblishAddDto addEmblishDto)
        {
            var result = await _EmblishService.AddEmblish(addEmblishDto);
            return Ok(result);

        }



        [HttpGet("Api/GetAll")]
        public async Task<IActionResult> GetEmblishList()
        {
            IEnumerable<EmblishResponseDto> results = await _EmblishService.GetEmblishList();
            return Ok(results);

        }

        [HttpPost("Api/GetById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Emblish = await _EmblishService.GetEmblishById(id);

            return Ok(Emblish);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmblish(int EmblishId)
        {
            EmblishResponseDto Emblish = await _EmblishService.DeleteEmblish(EmblishId);
            return Ok(Emblish);
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