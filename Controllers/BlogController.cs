﻿using BigonWebUI.Models;
using BigonWebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BigonWebUI.Controllers
{
    public class BlogController : Controller
    {

        private readonly DataContext _datacontext;
        public BlogController(DataContext dbcontext)
        {
            _datacontext = dbcontext;
        }
        public IActionResult Index()
        {

            //BlogVM blogVM = new BlogVM();


            //blogVM.Tags = _datacontext.Tags.ToList();

            return View();
            
        }
    }
}
