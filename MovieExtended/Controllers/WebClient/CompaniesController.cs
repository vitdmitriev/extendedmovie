using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;

namespace MovieExtended.Controllers.WebClient
{
    public class CompaniesController : ApiController
    {
        private readonly ISession _session;

        public CompaniesController(ISession session)
        {
            _session = session;
        }

        [Route("api/Companies")]
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _session.Query<Company>().ToArray();
        }

        [Route("api/Companies/{companyId}")]
        [HttpGet]
        public Company Get(Guid companyId)
        {
            return _session
                .Query<Company>()
                .SingleOrDefault(company => company.Id == companyId);
        }

        [Route("api/Companies")]
        [HttpPost]
        public Guid Post([FromBody] Company company)
        {
            if (company == null)
            {
                return Guid.Empty;
            }

            var companyId = _session.Save(company);
            _session.Flush();
            return (Guid) companyId;
        }
    }
}
