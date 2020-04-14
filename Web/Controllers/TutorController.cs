using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tutor_Database.Facades;

namespace Web.Controllers
{
    [Authorize]
    public class TutorController : ApiController
    {
        private TutorFacade tutorFcd = new TutorFacade();

        //[HttpPut]
        //[Route("api/Tutor/UpdateDetails")]
        ////public IHttpActionResult UpdateDetails()
        ////{

        ////}
    }
}
