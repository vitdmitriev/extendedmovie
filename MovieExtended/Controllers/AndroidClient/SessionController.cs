using System;
using System.Linq;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;

namespace MovieExtended.Controllers.AndroidClient
{
    public class SessionController : ApiController
    {
        private readonly ISession _session;

        public SessionController(ISession session)
        {
            _session = session;
        }

        [Route("api/Sessions/Login/{qr}")]
        [HttpGet]
        public Guid Login(string qr)
        {
            var exists = _session.Query<Movie>().Any(movie => movie.Id == Guid.Parse(qr));
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
