using Khayati.ServiceContracts;
using Khayati.ServiceContracts;
using Khayati.Core.DTO;
using Microsoft.AspNetCore.Mvc;

//using Khayati.Core.DTO.Embellishment;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmbellishmentController : Controller
    {
        //private readonly IEmbellishmentService _EmbellishmentService;
        private readonly IEmbellishmentService _EmbellishmentService;

        public EmbellishmentController(IEmbellishmentService EmbellishmentService)
        {
            _EmbellishmentService = EmbellishmentService;
            //_EmbellishmentService = EmbellishmentService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<EmbellishmentResponseDto> results = await _EmbellishmentService.GetEmbellishmentList();
            return View(results);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Create(EmbellishmentAddDto addEmbellishmentDto)
        //{
        //    var result = await _EmbellishmentService.AddEmbellishment(addEmbellishmentDto);
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var result = await _EmbellishmentService.GetEmbellishmentById(id);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(result);

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(EmbellishmentResponseDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    await _EmbellishmentService.UpdateEmbellishment(dto);

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet("api/Embellishment/Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _EmbellishmentService.DeleteEmbellishment(id);
        //    return Ok("deleted susscefully");
        //}



        ////public async Task<IActionResult> Index()
        ////{
        ////    HttpClient client = new HttpClient();
        ////    client.BaseAddress = new Uri("https://localhost:7235/");
        ////    HttpResponseMessage res = await client.GetAsync("api/Embellishment/GetAll");

        ////    if (!res.IsSuccessStatusCode)
        ////    {
        ////        return NotFound();
        ////    }

        ////    var result = res.Content.ReadAsStringAsync().Result;
        ////    var studentList = JsonConvert.DeserializeObject<IEnumerable<EmbellishmentResponseDto>>(result);


        ////    // var result = await _EmbellishmentService.GetEmbellishmentList();
        ////    return View(studentList);
        ////}
    }
}