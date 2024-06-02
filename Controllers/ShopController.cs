using BigonWebUI.Models;
using BigonWebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BigonWebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataContext _datacontext;
        public ShopController(DataContext dbcontext)
        {
            _datacontext = dbcontext;
        }

        public IActionResult Index()
        {

            //ShopVM shopVM = new ShopVM();


            //shopVM.manufactures = _datacontext.Manufactures.ToList();

            return View();

        }
    }
}
