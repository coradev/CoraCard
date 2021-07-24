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
                        entity.UserAvatar = "UserAvatar/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Upload/Image/Avatar/UserAvatar/"), fileName);
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

        public ActionResult ChangePassword()
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            var Message = TempData["Message"];
            ViewBag.Message = Message;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDAO();
                    var userlogged = dao.GetUserByUserName(user.UserName);
                    if (userlogged.PASSWORD != model.OldPassword)
                    {
                        ModelState.AddModelError("", "Incorrect old password!");
                    }
                    else
                    {
                        if (model.NewPassword == null || model.NewPassword.Trim().Length < 1)
                        {
                            ModelState.AddModelError("", "New password error!");
                        }else if (userlogged.PASSWORD == model.NewPassword)
                        {
                            ModelState.AddModelError("", "Same old password!");
                        }
                        else
                        {
                            userlogged.PASSWORD = model.NewPassword;
                            dao.ChangePassword(userlogged);
                            TempData["Message"] = "Password has been changed!";
                            return RedirectToAction("ChangePassword", "Info", new { area = "Profile" });
                        }                        
                    }
                }
            }
            return View();
        }
    }
}