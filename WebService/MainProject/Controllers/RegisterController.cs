using EFDataAccess.DAL;
using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.Title = "Register";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Exclude = "AVATAR, BIOGRAPHY, STATUSID")] User user)
        {
            var udao = new UserDAO();
            var sdao = new SocialDAO();

            var userName = udao.GetUserByUserName(user.USERNAME);
            var userMail = udao.GetUserByEmail(user.EMAIL);

            if (userName != null)
            {
                ModelState.AddModelError("", "Username existed!");
            }
            else if (userMail != null)
            {
                ModelState.AddModelError("", "Email existed!");
            }
            else
            {
                // add role for new user
                var uid = udao.AddUser(user);
                var rid = udao.GetRoleIdByRoleName("Normal user");
                DataAccessLayer.UserDAO.AddUserRole(uid, rid);

                // add social link for new user
                Social social = new Social();
                social.NAME = "Email address";
                social.LINK = "mailto:" + user.EMAIL;
                social.IMAGE = "gmail.png";
                var sid1 = sdao.AddSocial(social);
                DataAccessLayer.SocialDAO.AddUserSocial(uid, sid1);

                social.NAME = "Website";
                social.LINK = "https://kotzava.com";
                social.IMAGE = "earth-globe.png";
                var sid2 = sdao.AddSocial(social);
                DataAccessLayer.SocialDAO.AddUserSocial(uid, sid2);

                TempData["Message"] = "Register successfully !";
            }
            return RedirectToAction("Index", "Login");
        }
    }
}