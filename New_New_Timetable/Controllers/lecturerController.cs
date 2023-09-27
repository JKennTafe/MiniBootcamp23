using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using New_New_Timetable.Controllers;

namespace New_New_Timetable.Controllers
{
    public class lecturerController : Controller
    {
        private Initial_DatabaseEntities3 db = new Initial_DatabaseEntities3();

        // GET: lecturer
        public ActionResult Index()
        {
            var lecturers = db.lecturers.Include(l => l.lecturer_name);
            return View(db.lecturers.ToList());
        }

        // GET: lecturer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturer lecturer = db.lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // GET: lecturer/Create
        public ActionResult Create()
        {
            ViewBag.pub_id = new SelectList(db.lecturers, "Lecturer ID", "Lecturer Name");
            return View();
        }

        // POST: lecturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lecturer_id,lecturer_name")] lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.lecturers.Add(lecturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lecturer_id = new SelectList(db.lecturers, "Lecturer ID", "Lecturer Name", lecturer.lecturer_id);
            return View(lecturer);
        }

        // GET: lecturer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturer lecturer = db.lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            ViewBag.lecturer_id = new SelectList(db.lecturers, "Lecturer ID", "Lecturer Name", lecturer.lecturer_id);
            return View(lecturer);
        }

        // POST: lecturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lecturer_id,lecturer_name")] lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lecturer_id = new SelectList(db.lecturers, "Lecturer ID", "Lecturer Name", lecturer.lecturer_id);
            return View(lecturer);
        }

        // GET: lecturer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecturer lecturer = db.lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // POST: lecturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lecturer lecturer = db.lecturers.Find(id);
            db.lecturers.Remove(lecturer);
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
