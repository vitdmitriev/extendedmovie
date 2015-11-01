﻿using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;

namespace MovieExtended.Controllers.AndroidClient
{
    public class SessionController : ApiController
    {
        private readonly ISession _session;
        private readonly SessionKeeper _sessionKeeper;

        public SessionController(ISession session, SessionKeeper sessionKeeper)
        {
            _session = session;
            _sessionKeeper = sessionKeeper;
        }

        [Route("api/Sessions/Login/{qr}")]
        [HttpGet]
        public Guid Login(string qr)
        {
            var exists = _session.Query<Movie>().Any(movie => movie.Id == Guid.Parse(qr));
            if (!exists)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            var sessionId = _sessionKeeper.CreateSession(Guid.Parse(qr));
            return sessionId;
        }

        [Route("api/Sessions/{sessionId}")]
        [HttpGet]
        public SessionState GetSessionState(Guid sessionId)
        {
            if (!_sessionKeeper.CheckIfSessionExists(sessionId))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            return _sessionKeeper.GetSessionState(sessionId);
        }
    }
}
