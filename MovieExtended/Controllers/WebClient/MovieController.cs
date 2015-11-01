using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;

namespace MovieExtended.Controllers.WebClient
{
    public class MovieController : ApiController
    {
        private readonly ISession _session;

        public MovieController(ISession session)
        {
            _session = session;
        }

        [Route("api/Cinemas/{cinemaId}/Movies")]
        public IEnumerable<Movie> Get(Guid cinemaId)
        {
            return _session
                .Query<Movie>()
                .Where(movie => movie.CinemaId == cinemaId);
        }

        [Route("api/Cinemas/{cinemaId}/Movies/{movieId}")]
        public Movie Get(Guid cinemaId, Guid movieId)
        {
            return _session
                .Query<Movie>()
                .Where(movie => movie.CinemaId == cinemaId)
                .SingleOrDefault(movie => movie.Id == movieId);
        }

        [Route("api/Cinemas/{cinemaId}/Movies")]
        public Guid Post(Guid cinemaId, [FromBody] Movie movie)
        {
            var movieId = _session.Save(movie);
            _session.Flush();
            return (Guid) movieId;
        }

        [Route("api/Movies/{movieId}")]
        public void Delete(Guid movieId)
        {
            var instance = _session.Query<Movie>()
                .SingleOrDefault(movie => movie.Id == movieId);
            if (instance != null)
            {
                _session.Delete(instance);
                _session.Flush();
            }
        }
    }
}
