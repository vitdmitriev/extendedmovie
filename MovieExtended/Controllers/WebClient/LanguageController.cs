using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers.WebClient
{
    public class LanguageController : ApiController
    {
        [Route("api/Movie/{movieId}/TrackLanguage")]
        public IEnumerable<Language> Get(Guid movieId)
        {
            return null;
        }

        [Route("api/Movie/{movieId}/TrackLanguage/{languageId}")]
        public Language Get(Guid movieId, Guid languageId)
        {
            return null;
        }

        [Route("api/Movie/{movieId}/TrackLanguage")]
        public Guid Post([FromBody]Language value)
        {
            return Guid.Empty;
        }

        [Route("api/Language/{languageId}")]
        public void Delete(Guid id)
        {
        }
    }
}
