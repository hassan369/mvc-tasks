using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class usersController : Controller
    {
        private Entities db = new Entities();

        // GET: users
        public ActionResult Index(string q, string SelectedOption)
        {
            var data = db.users.ToList();
            if (SelectedOption == "Fname")
            {
                 data = db.users.Where(x => x.First_Name.Contains(q) || q == null).ToList();

            }
            else if (SelectedOption == "Email")
            {
                data = db.users.Where(x => x.E_mail.Contains(q) || q == null).ToList();

            }
            else if (SelectedOption == "Lname")
            {
                data = db.users.Where(x => x.Last_name.Contains(q) || q == null).ToList();

            }
            return View(data);
        }

        public ActionResult Viewhaspartials()
        {
            var users = db.users.ToList();
            var products = db.Products.ToList();
            return View(Tuple.Create(users,products));
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,First_Name,Last_name,E_mail,Phone,Age,Job_title,Gender,image")] user user, HttpPostedFileBase image2, HttpPostedFileBase cv)
        {
            if (ModelState.IsValid)
            {
                if (image2 != null)
                {
                    if (!image2.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(user);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(image2.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    image2.SaveAs(path);
                    user.image = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(user);
                }

                if (cv != null)
                {
                    //if (!image2.ContentType.ToLower().StartsWith("image/"))
                    //{
                    //    ModelState.AddModelError("", "file uploaded is not an image");
                    //    return View(user);
                    //}
                    string folderPath = Server.MapPath("~/Content/CVs");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(cv.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    cv.SaveAs(path);
                    user.cv = "../Content/CVs/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an cv.");
                    return View(user);
                }





                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,First_Name,Last_name,E_mail,Phone,Age,Job_title,Gender")] user user, HttpPostedFileBase image2, HttpPostedFileBase cv)
        {
            if (ModelState.IsValid)
            {
                if (image2 != null)
                {
                    if (!image2.ContentType.ToLower().StartsWith("image/"))
                    {
                        ModelState.AddModelError("", "file uploaded is not an image");
                        return View(user);
                    }
                    string folderPath = Server.MapPath("~/Content/Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(image2.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    image2.SaveAs(path);
                    user.image = "../Content/Images/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an image.");
                    return View(user);
                }
                if (cv != null)
                {
                    //if (!image2.ContentType.ToLower().StartsWith("image/"))
                    //{
                    //    ModelState.AddModelError("", "file uploaded is not an image");
                    //    return View(user);
                    //}
                    string folderPath = Server.MapPath("~/Content/CVs");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fileName = Path.GetFileName(cv.FileName);
                    string path = Path.Combine(folderPath, fileName);
                    cv.SaveAs(path);
                    user.cv = "../Content/CVs/" + fileName;
                }
                else
                {
                    ModelState.AddModelError("", "Please upload an cv.");
                    return View(user);
                }


                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
