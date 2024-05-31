﻿using BigonWebUI.Helpers.Services;
using BigonWebUI.Models;
using BigonWebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace BigonWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;

        private readonly IEmailService _emailService;
        public HomeController(DataContext db,IEmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }
        public async Task< IActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task< IActionResult> Subscribe(string email) 
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

            if (dbEmail != null && dbEmail.IsApproved)
            {
                return Json(new
                {
                    error = true,
                    message = "Bu email artiq abune olub",


                });

            }

            var newSubscriber = new Subscriber
            {
                EmailAddress = email,
                CreatedAt = DateTime.Now,

            };

            _db.Subscribers.Add(newSubscriber);
            _db.SaveChanges();

            string token = $"demo-{newSubscriber.EmailAddress}-{newSubscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-bigon";
            token = HttpUtility.UrlEncode(token);

            string url = $"{Request.Scheme}://{Request.Host}/subscribe-approve?token={token}";
            string body = $"Please click to link accept subscription <a href=\"{url}\">Click!<a/>";
            await _emailService.SendMailAsync(email, "News Letter Subscription",body);


             

            return Ok(new
            {
                success=true,
                message = $"Bu {email} ugurla qeydiyyatdan kecdi",

            });
        }




        [Route("/subscribe-approve")]
        public async Task<IActionResult> SubscribeApprove(string token)
        {
            string pattern = @"#demo-(?<email>[-]*)-(?<date>\d{4}-\d{2}\s\d{2}:\d{2}:\d{2}. \d{3}";

            Match match = Regex.Match(token, pattern);

            if(!match.Success)
            {
                return Content("token is broken!");
            }

            string email = match.Groups["email"].Value;
            string dateStr = match.Groups["date"].Value;

            if(!DateTime.TryParseExact(dateStr,"yyyy-MM-dd HH:mm:ss.fff",null, DateTimeStyles.None, out DateTime date))
            {
                return Content("token is broken!");

            }
            var subscriber=await _db.Subscribers.FirstOrDefaultAsync(m=>m.EmailAddress.Equals(email) && m.CreatedAt==date);

            if (subscriber==null)
            {
                return Content("token is broken!");
            }

            if (!subscriber.IsApproved)
            {
                subscriber.IsApproved = true;
                subscriber.ApprovedAt = DateTime.UtcNow;
            }
            await _db.SaveChangesAsync();

            return Content($"Success: Email : {email}\n" +
                $"Date :{date}");
        }

    }
}