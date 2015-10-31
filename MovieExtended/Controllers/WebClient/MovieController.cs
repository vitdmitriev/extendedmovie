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
        private readonly ISessionFactory _sessionFactory;

        public MovieController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [Route("api/Cinemas/{cinemaId}/Movies")]
        public IEnumerable<Movie> Get(Guid cinemaId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session
                    .Query<Movie>()
                    .Where(movie => movie.Cinema.Id == cinemaId);
            }
        }

        [Route("api/Cinemas/{cinemaId}/Movies/{movieId}")]
        public Movie Get(Guid cinemaId, Guid movieId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session
                    .Query<Movie>()
                    .Where(movie => movie.Cinema.Id == cinemaId)
                    .SingleOrDefault(movie => movie.Id == movieId);
            }
        }

        [Route("api/Cinemas/{cinemaId}/Movies")]
        public Guid Post(Guid cinemaId, [FromBody]Movie movie)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var movieId = session.Save(movie);
                return (Guid) movieId;
            }
        }

        [Route("api/Movies/{movieId}")]
        public void Delete(Guid movieId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var instance = session.Query<Movie>()
                    .SingleOrDefault(movie => movie.Id == movieId);
                if (instance != null)
                {
                    session.Delete(instance);
                }
            }
        }
    }
}
