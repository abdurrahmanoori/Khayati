using Khayati.ServiceContracts;
using Khayati.Core.DTO;
using Microsoft.AspNetCore.Mvc;

using Khayati.Core.DTO.EmbellishmentTypeDto;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmbellishmentTypeController : Controller
    {
        //private readonly IEmbellishmentTypeService _embellishmentTypeService;
        private readonly IEmbellishmentTypeService _embellishmentTypeService;

        public EmbellishmentTypeController(IEmbellishmentTypeService EmbellishmentTypeService)
        {
            _embellishmentTypeService = EmbellishmentTypeService;
            //_embellishmentTypeService = EmbellishmentTypeService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<EmbellishmentTypeResponseDto> results = await _embellishmentTypeService.GetEmbellishmentTypeList();
            return View(results);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmbellishmentTypeAddDto addEmbellishmentTypeDto)
        {
            var result = await _embellishmentTypeService.AddEmbellishmentType(addEmbellishmentTypeDto);
            return Ok(result);

        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int  id)
        {

            var result = await _embellishmentTypeService.GetEmbellishmentTypeById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(new EmbellishmentTypeUpdateDto());

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmbellishmentTypeUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return View();

        }

        //public async Task<IActionResult> Index()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7235/");
        //    HttpResponseMessage res = await client.GetAsync("api/EmbellishmentType/GetAll");

        //    if (!res.IsSuccessStatusCode)
        //    {
        //        return NotFound();
        //    }

        //    var result = res.Content.ReadAsStringAsync().Result;
        //    var studentList = JsonConvert.DeserializeObject<IEnumerable<EmbellishmentTypeResponseDto>>(result);


        //    // var result = await _embellishmentTypeService.GetEmbellishmentTypeList();
        //    return View(studentList);
        //}
    }
}