using Khayati.Core.DTO.Customers;
using Khayati.Mvc.ViewModel;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Khayati.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class CustomerController : Controller
{
    //private readonly ICustomerService _customerService;
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
        //_customerService = customerService;
    }

    public async Task<IActionResult> Index()
    {
        var results = await _customerService.GetCustomerList();
        return View(results);
    }
    //[HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    //[HttpPost]
    public async Task<IActionResult> Create(CustomerAddVM customerAddVM)
    {
        var daata = HttpContext;

        var result = await _customerService.AddCustomer(customerAddVM.CustomerAdd);
        return RedirectToAction("Index");

    }

    //[HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _customerService.GetCustomerById(id);
        if (result is null)
        {
            return NotFound();
        }
        ViewBag.Customers = new SelectList(_customerService.GetCustomerList().Result.Response,
            nameof(CustomerResponseDto.CustomerId), nameof(CustomerResponseDto.Name));

        //return View(result.Response);
        return View(result);

    }

    //[HttpPost]
    //public async Task<IActionResult> Edit(RelativeUpdateDto dto)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest();
    //    }
    //    await _relativeService.UpdateRelative(dto.RelativeId, dto);

    //    return RedirectToAction(nameof(Index));
    //}

    //[HttpDelete("api/Customer/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _customerService.DeleteCustomer(id);
        return Ok("deleted susscefully");
    }
    //public async Task<IActionResult> Index()
    //{
    //    HttpClient client = new HttpClient();
    //    client.BaseAddress = new Uri("https://localhost:7235/");
    //    HttpResponseMessage res = await client.GetAsync("api/Customer/GetAll");

    //    if (!res.IsSuccessStatusCode)
    //    {
    //        return NotFound();
    //    }

    //    var result = res.Content.ReadAsStringAsync().Result;
    //    var studentList = JsonConvert.DeserializeObject<IEnumerable<CustomerResponseDto>>(result);


    //    // var result = await _customerService.GetCustomerList();
    //    return View(studentList);
    //}
}