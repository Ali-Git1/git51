using Microsoft.AspNetCore.Mvc;

namespace BigonApp.Controllers
{
    public class ContactUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
