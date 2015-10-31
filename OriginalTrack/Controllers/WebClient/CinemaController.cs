using System;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers.WebClient
{
    public class CinemaController : ApiController
    {
        [Route("api/Company/{companyId}/Cinemas")]
        public Cinema Get(Guid companyId)
        {
            return null;
        }
        
        [Route("api/Company/{companyId}/Cinemas")]
        public void Post(Guid companyId, [FromBody]Cinema value)
        {
        }

        [Route("api/Cinemas/{cinemaId}")]
        public void Delete(Guid cinemaId)
        {
        }
    }
}
