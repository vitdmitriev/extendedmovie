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
        private readonly ISessionFactory _sessionFactory;

        public LanguageController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [Route("api/Movies/{movieId}/TrackLanguages")]
        public IEnumerable<Language> Get(Guid movieId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session
                    .Query<Language>()
                    .Where(lang => lang.Movie.Id == movieId);
            }
        }

        [Route("api/Movies/{movieId}/TrackLanguages/{languageId}")]
        public Language Get(Guid movieId, Guid languageId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session
                    .Query<Language>()
                    .Where(lang => lang.Movie.Id == movieId)
                    .SingleOrDefault(lang => lang.Id == languageId);
            }
        }

        [Route("api/Movie/{movieId}/TrackLanguages")]
        public Guid Post([FromBody]Language language)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var languageId = session.Save(language);
                return (Guid) languageId;
            }
        }

        [Route("api/TrackLanguages/{languageId}")]
        public void Delete(Guid languageId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var instance = session
                    .Query<Language>()
                    .SingleOrDefault(lang => lang.Id == languageId);
                if (instance != null)
                {
                    session.Delete(instance);
                }
            }
        }
    }
}
