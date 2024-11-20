using Khayati.ServiceContracts;
using Khayati.ServiceContracts;
using Khayati.Core.DTO;
using Microsoft.AspNetCore.Mvc;

using Khayati.Core.DTO.Embellishments;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmbellishmentController : Controller
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
            return View();

        }

        
        public async Task<IActionResult> Index( )
        {
            var results =
                await _embellishmentService
                .GetEmbellishmentList();

            return View(results.Response);
        }

        [HttpPost("getById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Embellishment = await _embellishmentService.GetEmbellishmentById(id);

            return View();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishment(int EmbellishmentId)
        {
            EmbellishmentResponseDto Embellishment = await _embellishmentService.DeleteEmbellishment(EmbellishmentId);
            return View();
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