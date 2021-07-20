using MainProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Free Profile Card";
            ViewBag.Desc = "Touch the CoraCard tag on the phone to share information, reduce the time to exchange social networks such as Facebook, Instagram, Zalo, Phone, Email,...";
            return View();
        }
    }
}