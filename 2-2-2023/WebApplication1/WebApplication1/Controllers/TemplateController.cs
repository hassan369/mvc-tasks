using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TemplateController : Controller
    {
        private Entities db = new Entities();

        // GET: Template
        public ActionResult Index()
        {
            var data = db.templates.ToList();
            return View(data);
        }
    }
}