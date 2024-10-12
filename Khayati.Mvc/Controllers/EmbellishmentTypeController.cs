using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Controllers
{
    public class EmbellishmentTypeController : Controller
    {
        //private readonly IEmbellishmentTypeService _EmbellishmentTypeService;
        private readonly IEmbellishmentTypeService _EmbellishmentTypeService;

        public EmbellishmentTypeController(IEmbellishmentTypeService EmbellishmentTypeService)
        {
            _EmbellishmentTypeService = EmbellishmentTypeService;
            //_EmbellishmentTypeService = EmbellishmentTypeService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<EmbellishmentTypeResponseDto> results = await _EmbellishmentTypeService.GetEmbellishmentTypeList();
            return View(results);
        }
        [HttpGet]
        public IActionResult Create( )
        {
            return View();  
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmbellishmentTypeAddDto addEmbellishmentTypeDto)
        {
            var result = await _EmbellishmentTypeService.AddEmbellishmentType(addEmbellishmentTypeDto);
            return Ok(result);

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


        //    // var result = await _EmbellishmentTypeService.GetEmbellishmentTypeList();
        //    return View(studentList);
        //}
    }
}