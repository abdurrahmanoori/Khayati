using Khayati.ServiceContracts;
using Khayati.ServiceContracts;
using Khayati.Core.DTO;
using Microsoft.AspNetCore.Mvc;

using Khayati.Core.DTO.Embellishment;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmbellishmentController : Controller
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmbellishmentervice _Embellishmentervice;
        private readonly IEmbellishmentTypeService _embellishmentTypeService;
        
        
        
        public EmbellishmentController (IEmbellishmentervice Embellishmentervice ,  IEmbellishmentTypeService embellishmentTypeService)
        {
            _Embellishmentervice = Embellishmentervice;
            _embellishmentTypeService= embellishmentTypeService;    
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmbellishmentAddDto addEmbellishmentDto)
        {
            var result = await _Embellishmentervice.AddEmbellishment(addEmbellishmentDto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult>  Create( )
        {
            // Fetch data from the database
            var embellishmentTypes = await _embellishmentTypeService.GetEmbellishmentTypeList();

            // Use SelectList to prepare data for the dropdown
            ViewBag.EmbellishmentTypes = new SelectList(embellishmentTypes, "EmbellishmentTypeId", "Name");

            return View();
        }


        public async Task<IActionResult> Index( )
        {
            var results =
                await _Embellishmentervice
                .GetEmbellishmentList();

            return View(results.Response);
        }

        [HttpPost("getById")]
        public async Task<IActionResult> GitById(int id)
        {
            var Embellishment = await _Embellishmentervice.GetEmbellishmentById(id);

            return View();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishment(int EmbellishmentId)
        {
            var embellishment = await _Embellishmentervice.DeleteEmbellishment(EmbellishmentId);
            return View(embellishment.Response);
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