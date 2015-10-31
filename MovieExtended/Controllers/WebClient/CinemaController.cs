using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers.WebClient
{
    public class CinemaController : ApiController
    {
        [Route("api/Companies/{companyId}/Cinemas")]
        public IEnumerable<Cinema> Get(Guid companyId)
        {
            return null;
        }
        
        [Route("api/Companies/{companyId}/Cinemas")]
        public void Post(Guid companyId, [FromBody]Cinema value)
        {
        }

        [Route("api/Cinemas/{cinemaId}")]
        public void Delete(Guid cinemaId)
        {
        }
    }
}
