using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New_New_Timetable;

namespace New_New_Timetable.Models
{
    public class subject_lecturer_roomController : Controller
    {
        private Initial_DatabaseEntities3 db = new Initial_DatabaseEntities3();

        // GET: subject_lecturer_room
        public ActionResult Index()
        {
            var subject_lecturer_room = db.subject_lecturer_room.Include(s => s.lecturer).Include(s => s.room).Include(s => s.subject);
            return View(subject_lecturer_room.ToList());
        }

        // GET: subject_lecturer_room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject_lecturer_room subject_lecturer_room = db.subject_lecturer_room.Find(id);
            if (subject_lecturer_room == null)
            {
                return HttpNotFound();
            }
            return View(subject_lecturer_room);
        }

        // GET: subject_lecturer_room/Create
        public ActionResult Create()
        {
            ViewBag.lecturer_lecturer_id = new SelectList(db.lecturers, "lecturer_id", "lecturer_name");
            ViewBag.room_room_id = new SelectList(db.rooms, "room_id", "room_name");
            ViewBag.subject_subject_id = new SelectList(db.subjects, "subject_id", "subject_name");
            return View();
        }

        // POST: subject_lecturer_room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subject_subject_id,lecturer_lecturer_id,room_room_id")] subject_lecturer_room subject_lecturer_room)
        {
            if (ModelState.IsValid)
            {
                db.subject_lecturer_room.Add(subject_lecturer_room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lecturer_lecturer_id = new SelectList(db.lecturers, "lecturer_id", "lecturer_name", subject_lecturer_room.lecturer_lecturer_id);
            ViewBag.room_room_id = new SelectList(db.rooms, "room_id", "room_name", subject_lecturer_room.room_room_id);
            ViewBag.subject_subject_id = new SelectList(db.subjects, "subject_id", "subject_name", subject_lecturer_room.subject_subject_id);
            return View(subject_lecturer_room);
        }

        // GET: subject_lecturer_room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject_lecturer_room subject_lecturer_room = db.subject_lecturer_room.Find(id);
            if (subject_lecturer_room == null)
            {
                return HttpNotFound();
            }
            ViewBag.lecturer_lecturer_id = new SelectList(db.lecturers, "lecturer_id", "lecturer_name", subject_lecturer_room.lecturer_lecturer_id);
            ViewBag.room_room_id = new SelectList(db.rooms, "room_id", "room_name", subject_lecturer_room.room_room_id);
            ViewBag.subject_subject_id = new SelectList(db.subjects, "subject_id", "subject_name", subject_lecturer_room.subject_subject_id);
            return View(subject_lecturer_room);
        }

        // POST: subject_lecturer_room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subject_subject_id,lecturer_lecturer_id,room_room_id")] subject_lecturer_room subject_lecturer_room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject_lecturer_room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lecturer_lecturer_id = new SelectList(db.lecturers, "lecturer_id", "lecturer_name", subject_lecturer_room.lecturer_lecturer_id);
            ViewBag.room_room_id = new SelectList(db.rooms, "room_id", "room_name", subject_lecturer_room.room_room_id);
            ViewBag.subject_subject_id = new SelectList(db.subjects, "subject_id", "subject_name", subject_lecturer_room.subject_subject_id);
            return View(subject_lecturer_room);
        }

        // GET: subject_lecturer_room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject_lecturer_room subject_lecturer_room = db.subject_lecturer_room.Find(id);
            if (subject_lecturer_room == null)
            {
                return HttpNotFound();
            }
            return View(subject_lecturer_room);
        }

        // POST: subject_lecturer_room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subject_lecturer_room subject_lecturer_room = db.subject_lecturer_room.Find(id);
            db.subject_lecturer_room.Remove(subject_lecturer_room);
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
