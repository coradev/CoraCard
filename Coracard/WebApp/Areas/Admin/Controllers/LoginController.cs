using DataAccessLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var um = new UserModel();
                var result = um.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = um.GetByUserName(model.UserName);
                    var userSession = new UserLogin();

                    userSession.UserID = user.USERID;
                    userSession.UserName = user.USERNAME;

                    Session.Add(CommonConst.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }else if (result == 0)
                {
                    ModelState.AddModelError("", "Account doesn't exist!");
                }else if (result == -1)
                {
                    ModelState.AddModelError("", "Account exist! But must verify !");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Your account is banned!");
                }
                else
                {
                    ModelState.AddModelError("", "Check password!");
                }
            }
            return View("Index");
        }
    }
}