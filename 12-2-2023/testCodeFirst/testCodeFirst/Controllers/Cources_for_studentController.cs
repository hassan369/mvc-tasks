using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testCodeFirst.Models;

namespace testCodeFirst.Controllers
{
    public class Cources_for_studentController : Controller
    {
        private Entities db = new Entities();

        // GET: Cources_for_student
        public ActionResult Index()
        {
            var cources_for_student = db.Cources_for_student.Include(c => c.Cours).Include(c => c.Student);
            return View(cources_for_student.ToList());
        }

        // GET: Cources_for_student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cources_for_student cources_for_student = db.Cources_for_student.Find(id);
            if (cources_for_student == null)
            {
                return HttpNotFound();
            }
            return View(cources_for_student);
        }

        // GET: Cources_for_student/Create
        public ActionResult Create()
        {
            ViewBag.Cource_id = new SelectList(db.Courses, "id", "name");
            ViewBag.Student_id = new SelectList(db.Students, "id", "name");
            return View();
        }

        // POST: Cources_for_student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Student_id,Cource_id")] Cources_for_student cources_for_student)
        {
           
                if (ModelState.IsValid)
                {
                    db.Cources_for_student.Add(cources_for_student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Cource_id = new SelectList(db.Courses, "id", "name", cources_for_student.Cource_id);
                ViewBag.Student_id = new SelectList(db.Students, "id", "name", cources_for_student.Student_id);
                return View(cources_for_student);
           
            
        }

        // GET: Cources_for_student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cources_for_student cources_for_student = db.Cources_for_student.Find(id);
            if (cources_for_student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cource_id = new SelectList(db.Courses, "id", "name", cources_for_student.Cource_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "name", cources_for_student.Student_id);
            return View(cources_for_student);
        }

        // POST: Cources_for_student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Student_id,Cource_id")] Cources_for_student cources_for_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cources_for_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cource_id = new SelectList(db.Courses, "id", "name", cources_for_student.Cource_id);
            ViewBag.Student_id = new SelectList(db.Students, "id", "name", cources_for_student.Student_id);
            return View(cources_for_student);
        }

        // GET: Cources_for_student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cources_for_student cources_for_student = db.Cources_for_student.Find(id);
            if (cources_for_student == null)
            {
                return HttpNotFound();
            }
            return View(cources_for_student);
        }

        // POST: Cources_for_student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cources_for_student cources_for_student = db.Cources_for_student.Find(id);
            db.Cources_for_student.Remove(cources_for_student);
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
