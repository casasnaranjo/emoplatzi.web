﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmoPlatzi.web.Models;
using EmotionPlatzi.web.Models;

namespace EmotionPlatzi.web.Controllers
{
    public class EmoFacesController : Controller
    {
        private emotionplatzi db = new emotionplatzi();

        // GET: EmoFaces
        public ActionResult Index()
        {
            var emoFaces = db.EmoFaces.Include(e => e.Picture);
            return View(emoFaces.ToList());
        }

        // GET: EmoFaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoFace emoFace = db.EmoFaces.Find(id);
            if (emoFace == null)
            {
                return HttpNotFound();
            }
            return View(emoFace);
        }

        // GET: EmoFaces/Create
        public ActionResult Create()
        {
            ViewBag.EmopictureId = new SelectList(db.EmoPictures, "id", "name");
            return View();
        }

        // POST: EmoFaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,EmopictureId,x,y,width,heigh")] EmoFace emoFace)
        {
            if (ModelState.IsValid)
            {
                db.EmoFaces.Add(emoFace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmopictureId = new SelectList(db.EmoPictures, "id", "name", emoFace.EmopictureId);
            return View(emoFace);
        }

        // GET: EmoFaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoFace emoFace = db.EmoFaces.Find(id);
            if (emoFace == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmopictureId = new SelectList(db.EmoPictures, "id", "name", emoFace.EmopictureId);
            return View(emoFace);
        }

        // POST: EmoFaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,EmopictureId,x,y,width,heigh")] EmoFace emoFace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emoFace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmopictureId = new SelectList(db.EmoPictures, "id", "name", emoFace.EmopictureId);
            return View(emoFace);
        }

        // GET: EmoFaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmoFace emoFace = db.EmoFaces.Find(id);
            if (emoFace == null)
            {
                return HttpNotFound();
            }
            return View(emoFace);
        }

        // POST: EmoFaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmoFace emoFace = db.EmoFaces.Find(id);
            db.EmoFaces.Remove(emoFace);
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
