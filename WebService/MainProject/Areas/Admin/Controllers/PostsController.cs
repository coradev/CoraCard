using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFDataAccess.EF;
using EFDataAccess.Models;
using MainProject.Controllers;
using MainProject.Models;

namespace MainProject.Areas.Admin.Controllers
{
    public class PostsController : RequireAdminController
    {
        private CoraCardDBContext db = new CoraCardDBContext();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Category).Include(p => p.User);
            return View(posts.ToList());
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.TITLE = model.PostTitle;
                post.DESCRIPTION = model.PostDesc;
                post.CONTENT = model.PostContent;
                post.UPDATETIME = DateTime.Now;
                post.CATEGORYID = model.CategoryId;
                post.USERID = db.Users.SingleOrDefault(x => x.USERNAME == "admin").USERID;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME", model.CategoryId);
            return View(model);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            PostModel entity = new PostModel();
            entity.PostId = post.POSTID;
            entity.PostTitle = post.TITLE;
            entity.PostContent = post.CONTENT;
            entity.PostDesc = post.DESCRIPTION;
            entity.CategoryId = post.CATEGORYID;

            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME", entity.CategoryId);
            return View(entity);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = db.Posts.Find(model.PostId);
                post.TITLE = model.PostTitle;
                post.DESCRIPTION = model.PostDesc;
                post.CONTENT = model.PostContent;
                post.UPDATETIME = DateTime.Now;
                post.CATEGORYID = model.CategoryId;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME", model.CategoryId);
            return View(model);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
