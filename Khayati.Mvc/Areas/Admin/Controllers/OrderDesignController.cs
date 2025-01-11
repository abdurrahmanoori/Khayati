using Khayati.ServiceContracts;
using Khayati.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Khayati.Core.Utility;
using Khayati.Core.DTO.OrderDesign;

namespace Khayati.Mvc.Areas.Admin.Controllers;

[Area(SD.Admin)]
public class OrderDesignController : Controller
{
    //private readonly IOrderDesignService _OrderDesignService;
    private readonly IOrderDesignService _OrderDesignService;

    public OrderDesignController(IOrderDesignService OrderDesignService)
    {
        _OrderDesignService = OrderDesignService;
        //_OrderDesignService = OrderDesignService;
    }

    //public async Task<IActionResult> Index()
    //{
    //    IEnumerable<OrderDesignResponseDto> results = await _OrderDesignService.GetOrderDesignList();
    //    return View(results);
    //}
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(OrderDesignAddDto addOrderDesignDto)
    {
        var result = await _OrderDesignService.AddOrderDesign(addOrderDesignDto);
        return Ok(result);

    }

    //public async Task<IActionResult> Index()
    //{
    //    HttpClient client = new HttpClient();
    //    client.BaseAddress = new Uri("https://localhost:7235/");
    //    HttpResponseMessage res = await client.GetAsync("api/OrderDesign/GetAll");

    //    if (!res.IsSuccessStatusCode)
    //    {
    //        return NotFound();
    //    }

    //    var result = res.Content.ReadAsStringAsync().Result;
    //    var studentList = JsonConvert.DeserializeObject<IEnumerable<OrderDesignResponseDto>>(result);


    //    // var result = await _OrderDesignService.GetOrderDesignList();
    //    return View(studentList);
    //}
}