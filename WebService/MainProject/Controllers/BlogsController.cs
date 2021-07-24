using EFDataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainProject.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            return View(dao.GetAllPost());
        }

        public ActionResult Detail(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error404", "Error", new { area = "" });
            }
            PostDAO dao = new PostDAO();
            var post = dao.GetPostById(id);
            if(post == null)
            {
                return RedirectToAction("Error404", "Error", new { area = "" });
            }

            ViewBag.OTHERPOST = dao.GetPostExcludeById(id, 2);

            return View(post);
            
        }
    }
}