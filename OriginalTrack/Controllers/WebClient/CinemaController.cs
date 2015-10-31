using System;
using System.Collections.Generic;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers.WebClient
{
    public class CinemaController : ApiController
    {
        // GET: api/Cinema
        public IEnumerable<Cinema> Get()
        {
            return null;
        }

        // GET: api/Cinema/5
        public Cinema Get(Guid id)
        {
            return null;
        }

        // POST: api/Cinema
        public void Post([FromBody]Cinema value)
        {
        }

        // DELETE: api/Cinema/5
        public void Delete(Guid id)
        {
        }
    }
}
