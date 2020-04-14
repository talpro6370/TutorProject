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
    public class TutorRegistrationController : ApiController
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        TutorFacade tutorFcd = new TutorFacade();
        

        [HttpPost]
        [Route("api/TutorRegistrationCtrl/SubmitData")]
        public IHttpActionResult SubmitTutorData(TutorDets tutorDetails)
        {
            long cityCode = HelperClass.GetCityCodeByCityName(tutorDetails.city);
            long profCode = HelperClass.GetProfessionCodeByName(tutorDetails.profession);
            Tutor tutor = new Tutor()
            {
                first_name = tutorDetails.first_name,
                last_name = tutorDetails.last_name,
                user_name = tutorDetails.user_name,
                password = tutorDetails.password,
                email = tutorDetails.email,
                city_code = cityCode,
                professsion_code = profCode,
                phone_number = tutorDetails.phone_number

            };
            try
            {
                if(tutorFcd.AddTutor(tutor)==true)
                {
                    RegisterBindingModel model = new RegisterBindingModel()
                    {
                        UserName = tutor.user_name,
                        Password = tutor.password,
                        ConfirmPassword = tutor.password
                    };
                    
                    log.Info($"New tutor created: {tutorDetails.first_name} {tutorDetails.last_name}");
                    return Ok(model);
                }
                else
                {
                    log.Error("User is already exist! Cannot create another instance!");
                    return Ok();

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw ex;
            }

        }
    }
}
