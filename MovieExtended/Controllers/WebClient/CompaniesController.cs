using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;

namespace MovieExtended.Controllers.WebClient
{
    public class CompaniesController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public CompaniesController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            return null;
        }

        // GET: api/Company/5
        public Company Get(Guid id)
        {
            return null;
        }

        // POST: api/Company
        public Guid Post([FromBody]Company company)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var companyId = session.Save(company);
                return (Guid) companyId;
            }
        }
    }
}
