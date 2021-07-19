using EFDataAccess.DAL;
using EFDataAccess.EF;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User entity)
        {
            var dao = new UserDAO();
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                if (entity.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(entity.ImageFile.FileName);
                    string extension = Path.GetExtension(entity.ImageFile.FileName);
                    fileName = user.UserName + fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    entity.AVATAR = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Upload/Image/Avatar/"), fileName);
                    entity.ImageFile.SaveAs(fileName);
                }
                else
                {
                    entity.AVATAR = dao.GetUserByUserName(user.UserName).AVATAR;
                }
                
                return RedirectToAction("Index");
            }
        }
    }
}