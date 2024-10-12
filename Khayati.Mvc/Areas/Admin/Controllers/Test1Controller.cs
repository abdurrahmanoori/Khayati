using Microsoft.AspNetCore.Mvc;

namespace Khayati.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Test1Controller : Controller
    {
        public IActionResult Index()
        {
            ValidateAntiForgeryTokenAttribute SSDF;
            return View();
        }
    }
}
