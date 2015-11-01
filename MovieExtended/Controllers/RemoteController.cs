using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;

namespace MovieExtended.Controllers
{
    public class RemoteController : ApiController
    {
        private readonly ISession _session;
        private readonly SessionKeeper _sessionKeeper;

        public RemoteController(ISession session, SessionKeeper sessionKeeper)
        {
            _session = session;
            _sessionKeeper = sessionKeeper;
        }

        [Route("api/Movies/{movieId}/States/{state}")]
        [HttpPost]
        public void ChangeMovieStatus(Guid movieId, SessionState state, [FromBody]string changingOccured)
        {
            var movieExists = _session.Query<Movie>().Any(movie => movie.Id == movieId);
            if (!movieExists)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var date = DateTime.Parse(changingOccured);
            _sessionKeeper.SetState(movieId, state, date);
        }
    }
}
