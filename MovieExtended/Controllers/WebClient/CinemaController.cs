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
        private readonly ISession _session;

        public CinemaController(ISession session)
        {
            _session = session;
        }


        [Route("api/Companies/{companyId}/Cinemas")]
        public IEnumerable<Cinema> Get(Guid companyId)
        {
            return _session.Query<Cinema>()
                    .Where(cinema => cinema.CompanyId == companyId);
        }
        
        [Route("api/Companies/{companyId}/Cinemas")]
        public Guid Post(Guid companyId, [FromBody]Cinema value)
        {
            var id = _session.Save(value);
            _session.Flush();
            return (Guid)id;
        }

        [Route("api/Cinemas/{cinemaId}")]
        public void Delete(Guid cinemaId)
        {
            var instance = _session.Query<Cinema>()
                    .SingleOrDefault(cinema => cinema.Id == cinemaId);
                if (instance != null)
                {
                    _session.Delete(instance);
                    _session.Flush();
                }
            
        }
    }
}
