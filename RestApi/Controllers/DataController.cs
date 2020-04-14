using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tutor_Database.RestApiHelper;

namespace RestApiData.Controllers
{
    public class DataController : ApiController
    {
        
        [HttpGet]
        [Route("api/DataController/GetProfessions")]
        public IHttpActionResult GetProfessions()
        {
            RestApiAllData rest = new RestApiAllData();
            return Ok(rest.GetProfessions());
        }

        [HttpGet]
        [Route("api/DataController/GetCities")]
        public IHttpActionResult GetCities()
        {
            RestApiAllData rest = new RestApiAllData();
            return Ok(rest.GetCities());
        }
    }
}
