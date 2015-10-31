using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers.WebClient
{
    public class CompanyController : ApiController
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
        public void Post([FromBody]Company company)
        {
        }
    }
}
