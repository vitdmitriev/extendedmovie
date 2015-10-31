using System;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers
{
    public class RemoteController : ApiController
    {
        [Route("api/Cinemas/{cinemaId}/States/{state}/OccuredOn/{changingOccured}")]
        [HttpPost]
        public void ChangeCinemaStatus(DateTime changingOccured, Guid cinemaId, SessionState state)
        {
        }
    }
}
