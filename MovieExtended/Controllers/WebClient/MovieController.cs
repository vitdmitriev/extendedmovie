using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers.WebClient
{
    public class MovieController : ApiController
    {
        [Route("api/Cinemas/{cinemaId}/Movies")]
        public IEnumerable<Movie> Get()
        {
            return null;
        }

        [Route("api/Cinemas/{cinemaId}/Movies/{movieId}")]
        public Movie Get(Guid cinemaId, Guid movieId)
        {
            return null;
        }

        [Route("api/Cinemas/{cinemaId}/Movies")]
        public Guid Post(Guid cinemaId, [FromBody]Movie value)
        {
            return Guid.Empty;
        }

        [Route("api/Movies/{movieId}")]
        public void Delete(Guid movieId)
        {
        }
    }
}
