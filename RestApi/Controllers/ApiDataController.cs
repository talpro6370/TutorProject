using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestApiData.Controllers
{
    public class ApiDataController : Controller
    {
        // GET: ApiData
        public ActionResult Index()
        {
            return View();
        }
    }
}