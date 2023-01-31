using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public string image()
        {
            return ("<a download='juce.png' href='~/images/juce.png'><img src='../images/juce.png'></a>");

        }

        public ActionResult AboutUs()
        {
            return Content("About");
        }
        public ActionResult ContactUs()
        {
            return Content("Contact");
        }
    }
}