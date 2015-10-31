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
        private readonly ISessionFactory _sessionFactory;

        public CompaniesController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [Route("api/Companies")]
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Query<Company>().ToArray();
            }
        }

        [Route("api/Companies/{companyId}")]
        [HttpGet]
        public Company Get(Guid companyId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session
                    .Query<Company>()
                    .SingleOrDefault(company => company.Id == companyId);
            }
        }

        [Route("api/Companies")]
        [HttpPost]
        public string Post([FromBody]Company company)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var companyId = session.Save(company);
                session.Flush();
                return (Guid) companyId + " saved!";
            }
        }
    }
}
