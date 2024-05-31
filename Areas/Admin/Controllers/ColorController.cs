﻿using BigonWebUI.Models;
using BigonWebUI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigonWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly DataContext _dbcontext;

        public ColorController(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var colors=_dbcontext.Colors.Where(c=>c.DeletedBy==null).ToList();
            return View(colors);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Color color)
        {
            color.CreatedAt = DateTime.Now;
            color.CreatedBy = 1;
            _dbcontext.Colors.Add(color);
            _dbcontext.SaveChanges();

            return RedirectToAction(nameof(Index));   //nameof ile yazdiqda olmayan bir sey yazmaq olmur amma stringle yazanda sehvlik ola biler 
        }

        public IActionResult Edit(int id)
        {
            var dbColor = _dbcontext.Colors.Find(id);

            if(dbColor==null)
            {
                return NotFound();
            }

            return View(dbColor);
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            var dbColor = _dbcontext.Colors.Find(color.Id);

            if (dbColor == null)
            {
                return NotFound();
            }

            dbColor.Name = color.Name;
            dbColor.HexCode = color.HexCode;
            dbColor.ModifiedAt = DateTime.UtcNow;
            dbColor.ModifiedBy = 2;

            _dbcontext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var dbColor = _dbcontext.Colors.Find(id);

            if (dbColor == null)
            {
                return NotFound();
            }

            return View(dbColor);
        }


        public IActionResult Remove(int id)
        {
            var dbColor = _dbcontext.Colors.Find(id);

            if (dbColor == null)
            {
                return Json(new
                {
                    error=true,
                    message="Data tapilmadi"
                });
            }


            dbColor.DeletedAt = DateTime.UtcNow;
            dbColor.DeletedBy = 2;

            _dbcontext.SaveChanges();


            return Ok(new
            {
                error=false,
                message="Data silindi"
            });
        }


       
    }
}
