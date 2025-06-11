using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

using Khayati.Core.DTO.EmbellishmentType;

namespace Khayati.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class EmbellishmentTypeController : Controller
{
    //private readonly IEmbellishmentTypeService _embellishmentTypeService;
    private readonly IEmbellishmentTypeService _embellishmentTypeService;

    public EmbellishmentTypeController(IEmbellishmentTypeService embellishmentTypeService)
    {
        _embellishmentTypeService = embellishmentTypeService;
        //_embellishmentTypeService = embellishmentTypeService;
    }

    public async Task<IActionResult> Index()
    {
        var results = await _embellishmentTypeService.GetEmbellishmentTypeList();
        return View(results.Response);
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
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _embellishmentTypeService.GetEmbellishmentTypeById(id);
        if (result == null)
        {
            return NotFound();
        }
        return View(result);

    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id,EmbellishmentTypeResponseDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _embellishmentTypeService.UpdateEmbellishmentType(id,dto);

        return RedirectToAction(nameof(Index));
    }

    //[HttpGet("api/EmbellishmentType/Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _embellishmentTypeService.DeleteEmbellishmentType(id);
        return Ok("deleted susscefully");
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