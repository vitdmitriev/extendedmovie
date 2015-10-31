using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers.WebClient
{
    public class MovieController : ApiController
    {
        [Route("api/Cinema/{cinemaId}/Movie")]
        public IEnumerable<Movie> Get()
        {
            return null;
        }

        [Route("api/Cinema/{cinemaId}/Movie/{movieId}")]
        public Movie Get(Guid cinemaId, Guid movieId)
        {
            return null;
        }

        [Route("api/Cinema/{cinemaId}/Movie")]
        public Guid Post(Guid cinemaId, [FromBody]Movie value)
        {
            return Guid.Empty;
        }

        [Route("api/Movie/{movieId}")]
        public void Delete(Guid movieId)
        {
        }
    }
}
