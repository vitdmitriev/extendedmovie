﻿using System;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers.AndroidClient
{
    public class SessionController : ApiController
    {
        [Route("api/Session/Login/{qr}")]
        [HttpGet]
        public Guid Login(string qr)
        {
            return Guid.Empty;
        }

        [Route("api/Session/{sessionId}")]
        [HttpGet]
        public SessionState GetSessionState(Guid sessionId)
        {
            return SessionState.Ready;
        }
    }
}
