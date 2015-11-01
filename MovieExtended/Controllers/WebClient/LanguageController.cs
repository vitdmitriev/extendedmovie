using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;

namespace MovieExtended.Controllers.WebClient
{
    public class LanguageController : ApiController
    {
        private readonly ISession _session;

        public LanguageController(ISession session)
        {
            _session = session;
        }

        [Route("api/Movies/{movieId}/TrackLanguages")]
        [HttpGet]
        public IEnumerable<Language> Get(Guid movieId)
        {
            return _session
                .Query<Language>()
                .Where(lang => lang.MovieId == movieId);
        }

        [Route("api/Movies/{movieId}/TrackLanguages/{languageId}")]
        [HttpGet]
        public Language Get(Guid movieId, Guid languageId)
        {
            return _session
                .Query<Language>()
                .Where(lang => lang.MovieId == movieId)
                .SingleOrDefault(lang => lang.Id == languageId);
        }

        [Route("api/Movies/{movieId}/TrackLanguages")]
        [HttpPost]
        public Guid Post([FromBody] Language language)
        {
            var languageId = _session.Save(language);
            _session.Flush();
            return (Guid) languageId;
        }

        [Route("api/TrackLanguages/{languageId}")]
        [HttpDelete]
        public void Delete(Guid languageId)
        {
            var instance = _session
                .Query<Language>()
                .SingleOrDefault(lang => lang.Id == languageId);
            if (instance != null)
            {
                _session.Delete(instance);
                _session.Flush();
            }
        }
    }
}
