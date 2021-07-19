using EFDataAccess.DAL;
using EFDataAccess.EF;
using EFDataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var dao = new UserDAO();
                User u = dao.GetUserByUserName(user.UserName);
                EditProfileModel entity = new EditProfileModel();
                entity.UserId = u.USERID;
                entity.UserFullName = u.FULLNAME;
                entity.UserBio = u.BIOGRAPHY;
                entity.UserAvatar = u.AVATAR;
                return View(entity);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileModel entity)
        {
            var dao = new UserDAO();
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];

            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                User u = dao.GetUserByUserName(user.UserName);
                if (ModelState.IsValid)
                {
                    if (entity.ImageFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(entity.ImageFile.FileName);
                        string extension = Path.GetExtension(entity.ImageFile.FileName);
                        fileName = user.UserName + fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        entity.UserAvatar = fileName;
                        fileName = Path.Combine(Server.MapPath("~/Upload/Image/Avatar/"), fileName);
                        entity.ImageFile.SaveAs(fileName);
                    }
                    else
                        entity.UserAvatar = u.AVATAR;

                    u.AVATAR = entity.UserAvatar;
                    u.BIOGRAPHY = entity.UserBio;
                    u.FULLNAME = entity.UserFullName;
                    dao.EditUser(u);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }

        // GET: Profile/Info
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(User user)
        {
            return View();
        }
    }
}