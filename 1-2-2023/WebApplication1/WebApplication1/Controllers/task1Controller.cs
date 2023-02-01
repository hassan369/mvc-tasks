using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class task1Controller : Controller
    {
        // GET: task1
        public ActionResult Index()
        {
            List<Models.Student> student = new List<Models.Student>();
            student.Add(new Models.Student{ID = 1, Name = "hassan", Major = "computer science" , Faculity="it" });
            student.Add(new Models.Student { ID = 2, Name = "odat", Major = "electrical engenering", Faculity = "engening" });
            ViewBag.Student = student;
            return View();
        }
    }
}