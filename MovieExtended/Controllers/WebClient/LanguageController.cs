using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers.WebClient
{
    public class LanguageController : ApiController
    {
        [Route("api/Movies/{movieId}/TrackLanguages")]
        public IEnumerable<Language> Get(Guid movieId)
        {
            return null;
        }

        [Route("api/Movies/{movieId}/TrackLanguages/{languageId}")]
        public Language Get(Guid movieId, Guid languageId)
        {
            return null;
        }

        [Route("api/Movie/{movieId}/TrackLanguages")]
        public Guid Post([FromBody]Language value)
        {
            return Guid.Empty;
        }

        [Route("api/Languages/{languageId}")]
        public void Delete(Guid languageId)
        {
        }
    }
}
