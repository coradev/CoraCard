using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFDataAccess.DAL;
using EFDataAccess.EF;

namespace MainProject.Areas.Profile.Controllers
{
    public class SocialsController : Controller
    {
        /**
         * Kiem tra xem user co du quyen edit hoac xoa social hay khong
         * Bat buoc user phai dang nhap roi
         * sid : Social id
         * uid : User id
         */
        private static bool CheckIdSocial(int sid, List<Social> listSocial)
        {
            bool check = false;
            foreach (Social s in listSocial)
            {
                if (s.SOCIALID == sid)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        public ActionResult Index()
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var dao = new SocialDAO();
                var listSocial = dao.ListAllSocialsByUserId(user.UserId);
                return View(listSocial);
            }
        }

        public ActionResult Create()
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Social social)
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                if (social.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(social.ImageFile.FileName);
                    string extension = Path.GetExtension(social.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    social.IMAGE = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Upload/Image/Icon/"), fileName);
                    social.ImageFile.SaveAs(fileName);
                }
                else
                {
                    social.IMAGE = "default.png";
                }
                var dao = new SocialDAO();
                var sid = dao.AddSocial(social);
                DataAccessLayer.SocialDAO.AddUserSocial(user.UserId, sid);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var dao = new SocialDAO();
                var listSocial = dao.ListAllSocialsByUserId(user.UserId);
                bool check = CheckIdSocial(id, listSocial);
                Social social;
                if (check)
                {
                    social = dao.GetSocial(id);
                    if (social == null)
                    {
                        return RedirectToAction("Error404", "Error", new { area = "" });
                    }
                }
                else
                {
                    return RedirectToAction("Error403", "Error", new { area = "" });
                }
                return View(social);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Social social)
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var dao = new SocialDAO();
                var listSocial = dao.ListAllSocialsByUserId(user.UserId);

                bool check = CheckIdSocial(social.SOCIALID, listSocial);
                if (check)
                {
                    if (social.ImageFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(social.ImageFile.FileName);
                        string extension = Path.GetExtension(social.ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        social.IMAGE = fileName;
                        fileName = Path.Combine(Server.MapPath("~/Upload/Image/Icon/"), fileName);
                        social.ImageFile.SaveAs(fileName);
                    }
                    else
                    {
                        social.IMAGE = dao.GetSocial(social.SOCIALID).IMAGE;
                    }

                    dao.EditSocial(social);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error403", "Error", new { area = "" });
                }
            }
        }

        public ActionResult Delete(int id)
        {

            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var dao = new SocialDAO();
                var listSocial = dao.ListAllSocialsByUserId(user.UserId);

                bool check = CheckIdSocial(id, listSocial);
                Social social;
                if (check)
                {
                    social = dao.GetSocial(id);
                    if (social == null)
                    {
                        return RedirectToAction("Error404", "Error", new { area = "" });
                    }
                }
                else
                {
                    return RedirectToAction("Error403", "Error", new { area = "" });
                }
                return View(social);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = (Common.UserLogin)Session[Common.CMConst.USER_SESSION];
            if (user == null)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                var dao = new SocialDAO();
                var listSocial = dao.ListAllSocialsByUserId(user.UserId);
                bool check = CheckIdSocial(id, listSocial);
                if (check)
                {
                    dao.DeleteSocial(id);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error403", "Error", new { area = "" });
                }
            }

        }
    }
}
