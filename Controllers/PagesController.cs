using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
