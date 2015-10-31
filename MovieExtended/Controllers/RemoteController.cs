using System;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers
{
    public class RemoteController : ApiController
    {
        [Route("api/Cinema/{cinemaId}/State/{state}/OccuredOn/{changingOccured}")]
        [HttpGet]
        public void ChangeCinemaStatus(DateTime changingOccured, Guid cinemaId, SessionState state)
        {
        }
    }
}
