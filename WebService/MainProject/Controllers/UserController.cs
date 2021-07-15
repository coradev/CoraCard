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
        // GET: User
        public ActionResult Detail(string UserName)
        {
            var dao = new UserDAO();

            if(UserName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Get user by username
            var user = dao.GetUserByUserName(UserName);
            // Redirect if user not found
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}