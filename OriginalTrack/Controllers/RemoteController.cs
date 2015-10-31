using System;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers
{
    public class RemoteController : ApiController
    {
        [Route("api/Cinema/{cinemaId}/State/{state}/OccuredOn/{changingOccured}")]
        public void ChangeCinemaStatus(DateTime changingOccured, Guid cinemaId, SessionState state)
        {
        }
    }
}
