using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Areas.Profile.Controllers
{
    public class InfoController : Controller
    {
        // GET: Profile/Info
        public ActionResult Index()
        {
            return View();
        }
    }
}