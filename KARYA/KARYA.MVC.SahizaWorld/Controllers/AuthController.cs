using KARYA.MODEL.Common.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KARYA.MVC.SahizaWorld.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLoginModel userLoginModel)
        {
            return View();
        }
    }
}
