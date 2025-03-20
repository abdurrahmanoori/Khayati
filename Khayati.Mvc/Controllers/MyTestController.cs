using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Controllers
{
    public class MyTestController : Controller
    {
        public IActionResult Index( )
        {
            return View();
        }
    }
}
