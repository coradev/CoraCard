﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFDataAccess.EF;
using EFDataAccess.Models;

namespace MainProject.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private CoraCardDBContext db = new CoraCardDBContext();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Category).Include(p => p.User);
            return View(posts.ToList());
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME");
            ViewBag.USERID = new SelectList(db.Users, "USERID", "USERNAME");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "POSTID,TITLE,DESCRIPTION,CONTENT,UPDATETIME,CATEGORYID,USERID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME", post.CATEGORYID);
            ViewBag.USERID = new SelectList(db.Users, "USERID", "USERNAME", post.USERID);
            return View(post);
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
            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME", post.CATEGORYID);
            ViewBag.USERID = new SelectList(db.Users, "USERID", "USERNAME", post.USERID);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "POSTID,TITLE,DESCRIPTION,CONTENT,UPDATETIME,CATEGORYID,USERID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATEGORYID = new SelectList(db.Categories, "CATEGORYID", "NAME", post.CATEGORYID);
            ViewBag.USERID = new SelectList(db.Users, "USERID", "USERNAME", post.USERID);
            return View(post);
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


        public ActionResult AddPost()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPost(PostModel postModel)
        {
            return View(postModel);
        }
    }
}
