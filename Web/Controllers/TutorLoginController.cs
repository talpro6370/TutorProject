using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tutor_Database;
using Tutor_Database.Facades;
using Tutor_Database.Pocos;
using Web.Models;
using WebApi.Models;

namespace Web.Controllers
{
    public class TutorLoginController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        TutorFacade tutorFcd = new TutorFacade();

        [HttpPost]
        [Route("api/TutorLoginCtrl/LoginData")]
        public IHttpActionResult LoginData(TutorLoginDets tutorDets)
        {
            try
            {
                if (tutorFcd.GetTutorByUserName(tutorDets.username) != null)
                {
                    log.Info($"{tutorDets.username} logged in");
                    return Ok(tutorDets.username + tutorDets.password);
                }
                return Ok(); // Returning an empty response = User not found. 
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }
        }
    }
}
