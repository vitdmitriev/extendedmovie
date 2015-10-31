using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;

namespace MovieExtended.Controllers.WebClient
{
    public class CinemaController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public CinemaController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [Route("api/Companies/{companyId}/Cinemas")]
        public IEnumerable<Cinema> Get(Guid companyId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Query<Cinema>()
                    .Where(cinema => cinema.Company.Id == companyId);
            }
        }
        
        [Route("api/Companies/{companyId}/Cinemas")]
        public Guid Post(Guid companyId, [FromBody]Cinema value)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var id = session.Save(value);
                return (Guid) id;
            }
        }

        [Route("api/Cinemas/{cinemaId}")]
        public void Delete(Guid cinemaId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var instance = session.Query<Cinema>()
                    .SingleOrDefault(cinema => cinema.Id == cinemaId);
                if (instance != null)
                {
                    session.Delete(instance);
                }
            }
        }
    }
}
