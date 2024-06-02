using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
