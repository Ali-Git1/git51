using Microsoft.AspNetCore.Mvc;

namespace BigonWebUI.Controllers
{
    public class ContactUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
