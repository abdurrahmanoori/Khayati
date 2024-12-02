using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

using Khayati.Core.DTO.Relative;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RelativeController : Controller
    {
        //private readonly IRelativeService _relativeService;
        private readonly IRelativeService _relativeService;

        public RelativeController(IRelativeService RelativeService)
        {
            _relativeService = RelativeService;
            //_relativeService = RelativeService;
        }

        public async Task<IActionResult> Index( )
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult Create( )
        {

            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Create(RelativeAddDto addRelativeDto)
        {
            var result = await _relativeService.AddRelative(addRelativeDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _relativeService.GetRelativeById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(RelativeResponseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //await _relativeService.UpdateRelative(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("api/Relative/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _relativeService.DeleteRelative(id);
            return Ok("deleted susscefully");
        }



        //public async Task<IActionResult> Index()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7235/");
        //    HttpResponseMessage res = await client.GetAsync("api/Relative/GetAll");

        //    if (!res.IsSuccessStatusCode)
        //    {
        //        return NotFound();
        //    }

        //    var result = res.Content.ReadAsStringAsync().Result;
        //    var studentList = JsonConvert.DeserializeObject<IEnumerable<RelativeResponseDto>>(result);


        //    // var result = await _relativeService.GetRelativeList();
        //    return View(studentList);
        //}
    }
}