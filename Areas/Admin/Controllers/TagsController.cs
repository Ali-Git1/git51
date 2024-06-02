using BigonApp.Infrastructure.Entities;
using BigonApp.Models;
using BigonApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigonApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagsController : Controller
    {
        private readonly DataContext _db;

        public TagsController(DataContext db)
        {
            _db = db;
        }

     

        public IActionResult Index()
        {

            BlogVM blogvm = new BlogVM();
            blogvm.Tags = _db.Tags.ToList();
            return View(blogvm);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tags)
        {
            tags.CreatedAt = DateTime.Now;
            tags.CreatedBy = 1;
            _db.Tags.Add(tags);
            _db.SaveChanges();

            return RedirectToAction("index");   //nameof ile yazdiqda olmayan bir sey yazmaq olmur amma stringle yazanda sehvlik ola biler 
        }
    }
}
