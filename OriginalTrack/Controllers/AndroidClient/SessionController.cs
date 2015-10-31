using System;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers.AndroidClient
{
    public class SessionController : ApiController
    {
        [Route("api/Session/Login/{qr}")]
        public Guid Login(string qr)
        {
            return Guid.Empty;
        }

        [Route("api/Session/{sessionId}")]
        public SessionState GetSessionState(Guid sessionId)
        {
            return SessionState.Ready;
        }
    }
}
