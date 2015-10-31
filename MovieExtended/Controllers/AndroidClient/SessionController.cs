using System;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers.AndroidClient
{
    public class SessionController : ApiController
    {
        [Route("api/Sessions/Login/{qr}")]
        [HttpGet]
        public Guid Login(string qr)
        {
            return Guid.Empty;
        }

        [Route("api/Sessions/{sessionId}")]
        [HttpGet]
        public SessionState GetSessionState(Guid sessionId)
        {
            return SessionState.Ready;
        }
    }
}
