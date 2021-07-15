using MainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDataAccess.DAL;
using MainProject.Common;

namespace MainProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, model.Password);
                if(result == 1)
                {
                    // correct username and password
                    var user = dao.GetUserByUserName(model.UserName);

                    var userSession = new UserLogin();
                    userSession.UserId = user.USERID;
                    userSession.UserName = user.USERNAME;
                    userSession.RoleId = user.Roles.Select(r => r.ROLEID).FirstOrDefault();
                    // create new session for user login
                    Session[CMConst.USER_SESSION] = userSession;
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account doesn't exist!");
                }
                else if (result == -1)
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