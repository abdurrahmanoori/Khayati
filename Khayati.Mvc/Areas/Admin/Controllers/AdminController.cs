using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index( )
        {
            return View();
        }
    }
}
