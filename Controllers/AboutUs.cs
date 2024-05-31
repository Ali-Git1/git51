using Microsoft.AspNetCore.Mvc;

namespace BigonWebUI.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
