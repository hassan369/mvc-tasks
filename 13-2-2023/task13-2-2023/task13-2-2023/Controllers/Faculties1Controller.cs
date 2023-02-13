using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using task13_2_2023.Models;

namespace task13_2_2023.Controllers
{
    public class Faculties1Controller : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Faculties1
        public IQueryable<Faculty> GetFaculties()
        {
            return db.Faculties;
        }

        // GET: api/Faculties1/5
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult GetFaculty(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        // PUT: api/Faculties1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFaculty(int id, Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculty.id)
            {
                return BadRequest();
            }

            db.Entry(faculty).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Faculties1
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult PostFaculty(Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faculties.Add(faculty);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = faculty.id }, faculty);
        }

        // DELETE: api/Faculties1/5
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult DeleteFaculty(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }

            db.Faculties.Remove(faculty);
            db.SaveChanges();

            return Ok(faculty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacultyExists(int id)
        {
            return db.Faculties.Count(e => e.id == id) > 0;
        }
    }
}