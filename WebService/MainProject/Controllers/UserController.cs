using EFDataAccess.DAL;
using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Detail(string UserName)
        {
            var dao = new UserDAO();

            if (UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Get user by username
            var user = dao.GetUserByUserName(UserName);
            // Redirect if user not found
            if (user == null)
            {
                return RedirectToAction("Error404", "Error", new { area = "" });
            }

            // 1 is active, 2 watting, 3 banned
            if (user.Status.STATUSID == 1)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Error403", "Error", new { area = "" });
            }
        }
    }
}