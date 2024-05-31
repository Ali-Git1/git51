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

            ShopVM shopVM = new ShopVM();

            shopVM.colors = [.. _datacontext.Colors.Where(x=>x.DeletedBy==null)];

            return View(shopVM);

        }

        

        
    }
}
