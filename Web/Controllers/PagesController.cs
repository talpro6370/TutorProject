using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PagesController : Controller
    {
        
        public ActionResult RegistrationPage()
        {
            return new FilePathResult("~/Views/Pages/RegistrationPage.html","text/html");
        }
        public ActionResult RegForm2()
        {
            return new FilePathResult("~/Views/Pages/RegForm2.html", "text/html");
        }
        public ActionResult TutorLoginPage()
        {
            return new FilePathResult("~/Views/Pages/TutorLoginPage.html", "text/html");
        }
        public ActionResult TutorHomePage()
        {
            return new FilePathResult("~/Views/Pages/TutorHomePage.html", "text/html");
        }
    }
}