using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            ViewBag.Title = "View Card - CoraCard";
            ViewBag.RootUrl = Request.Url.Host.ToString();
            return View();
        }
    }
}