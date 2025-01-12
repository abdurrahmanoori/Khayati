using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Khayati.Core.DTO.Measurement;
using Microsoft.AspNetCore.Mvc.Rendering;
using Khayati.Core.DTO;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MeasurementController : Controller
    {
        //private readonly IMeasurementService _measurementService;
        private readonly IMeasurementService _measurementService;
        private readonly ICustomerService _customerService;

        public MeasurementController(IMeasurementService measurementService, ICustomerService customerService)
        {
            _measurementService = measurementService;
            _customerService = customerService;
            //_measurementService = MeasurementService;
        }

        public async Task<IActionResult> Index( )
        {
            var list = await _measurementService.GetMeasurementList();
            return View(list.Response);
        }
        [HttpGet]
        public async Task<IActionResult> Create( )
        {
            ViewBag.Customers = new SelectList(await _customerService.GetCustomerList(), nameof(CustomerResponseDto.CustomerId), nameof(CustomerResponseDto.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MeasurementAddDto addMeasurementDto)
        {
            var result = await _measurementService.AddMeasurement(addMeasurementDto);
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var result = await _measurementService.GetMeasurementById(id);
        //    if (result is null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.Customers = new SelectList(await _customerService.GetCustomerList(), nameof(CustomerResponseDto.CustomerId), nameof(CustomerResponseDto.Name));
        //    return View(result.Response);

        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(MeasurementUpdateDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    await _measurementService.UpdateMeasurement(dto.MeasurementId, dto);

        //    return RedirectToAction(nameof(Index));
        //}

        [HttpDelete("api/Measurement/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _measurementService.DeleteMeasurement(id);
            return Ok("deleted susscefully");
        }



        //public async Task<IActionResult> Index()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://localhost:7235/");
        //    HttpResponseMessage res = await client.GetAsync("api/Measurement/GetAll");

        //    if (!res.IsSuccessStatusCode)
        //    {
        //        return NotFound();
        //    }

        //    var result = res.Content.ReadAsStringAsync().Result;
        //    var studentList = JsonConvert.DeserializeObject<IEnumerable<MeasurementResponseDto>>(result);


        //    // var result = await _measurementService.GetMeasurementList();
        //    return View(studentList);
        //}
    }
}