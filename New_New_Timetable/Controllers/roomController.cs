using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using New_New_Timetable;

namespace New_New_Timetable.Controllers
{
    public class roomController : Controller
    {
        private Initial_DatabaseEntities3 db = new Initial_DatabaseEntities3();

        // GET: room
        public ActionResult Index()
        {
            var rooms = db.rooms.Include(r => r.room_name);
            return View(db.rooms.ToList());
        }

        // GET: room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "room_id,room_name")] room room)
        {
            if (ModelState.IsValid)
            {
                db.rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.room = new SelectList(db.rooms, "Room ID", "Room Name", room.room_id);
            return View(room);
        }

        // GET: room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.room = new SelectList(db.rooms, "Room ID", "Room Name", room.room_id);
            return View(room);
        }

        // POST: room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "room_id,room_name")] room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.room = new SelectList(db.rooms, "Room ID", "Room Name", room.room_id);
            return View(room);
        }

        // GET: room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.room = new SelectList(db.rooms, "Room ID", "Room Name", room.room_id);
            return View(room);
        }

        // POST: room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            room room = db.rooms.Find(id);
            db.rooms.Remove(room);
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
