using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeRestController : Controller
    {
        public ActionResult RefistrationPage()
        {
            ViewBag.Title = "Home Page";

            return new FilePathResult("~/Views/Pages/RefistrationPage.html","text/html");
        }
    }
}
