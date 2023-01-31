using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HassanController : Controller
    {
        // GET: Hassan
        public ActionResult actoin1()
        {
            return Content("Action1");
        }
        public ActionResult actoin2()
        {
            return Content("Action2");
        }
        public ActionResult actoin3()
        {
            return Content("Action3");
        }
        public ActionResult actoin4()
        {
            return Content("Action4");
        }
    }
}