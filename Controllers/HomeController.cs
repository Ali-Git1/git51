using BigonWebUI.Models;
using BigonWebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BigonWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;
        public HomeController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Subscribe(string email) 
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if(!isEmail)
            {
                return Json(new
                {
                    error = true,
                    message="Zehmet olmasa duzgun email daxil edin",

                });

            }

            var dbEmail = _db.Subscribers.FirstOrDefault(x => x.EmailAddress == email);

            if (dbEmail != null && !dbEmail.IsApproved)
            {
                return Json(new
                {
                    error = true,
                    message = "Bu email artiq qeydiyyatdan kecib zehmet olmasa inboxa kecib tesdiq edin",


                });

            }

            var newSubscriber = new Subscriber
            {
                EmailAddress = email,
                CreatedAt = DateTime.Now,

            };

            _db.Subscribers.Add(newSubscriber);
            _db.SaveChanges();

             

            return Ok(new
            {
                success=true,
                message = $"Bu {email} ugurla qeydiyyatdan kecdi",

            });
        }

    }
}
