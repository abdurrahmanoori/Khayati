using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Khayati.Core.DTO.Relative;
using Microsoft.AspNetCore.Mvc.Rendering;
using Khayati.Core.DTO.Customers;

namespace Khayati.Mvc.Areas.Admin.Controllers;

[Area("Admin")]

public class RelativeController : Controller
{
    //private readonly IRelativeService _relativeService;
    private readonly IRelativeService _relativeService;
    private readonly ICustomerService _customerService;

    public RelativeController(IRelativeService relativeService, ICustomerService customerService)
    {
        _relativeService = relativeService;
        _customerService = customerService;
        //_relativeService = RelativeService;
    }

    public async Task<IActionResult> Index( )
    {
        var list = await _relativeService.GetRelativeList();
        return View(list.Response);
    }
    [HttpGet]
    public async Task<IActionResult> Create( )
    {
        ViewBag.Customers = new SelectList( _customerService.GetCustomerList().Result.Response, nameof(CustomerResponseDto.CustomerId), nameof(CustomerResponseDto.Name));
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
        if (result is null)
        {
            return NotFound();
        }
        ViewBag.Customers = new SelectList(_customerService.GetCustomerList().Result.Response, nameof(CustomerResponseDto.CustomerId), nameof(CustomerResponseDto.Name));
        return View(result.Response);

    }

    [HttpPost]
    public async Task<IActionResult> Edit(RelativeUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _relativeService.UpdateRelative(dto.RelativeId, dto);

        return RedirectToAction(nameof(Index));
    }

    [HttpDelete("api/relative/delete")]
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