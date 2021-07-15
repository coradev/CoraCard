using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error404()
        {
            ViewBag.Title = "404";
            return View();
        }
        public ActionResult Error403()
        {
            ViewBag.Title = "403";
            return View();
        }
        public ActionResult Error500()
        {
            ViewBag.Title = "500";
            return View();
        }
    }
}