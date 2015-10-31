using System;
using System.Collections.Generic;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers.WebClient
{
    public class CompaniesController : ApiController
    {
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
            throw new NotImplementedException();
        }
    }
}
