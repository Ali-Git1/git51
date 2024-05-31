using Microsoft.AspNetCore.Mvc;

namespace BigonWebUI.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
