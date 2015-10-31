using System;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers
{
    public class LanguageController : ApiController
    {
        // GET: api/Language/5
        public Language Get(Guid id)
        {
            return null;
        }

        // POST: api/Language
        public Guid Post([FromBody]Language value)
        {
            return Guid.Empty;
        }

        // DELETE: api/Language/5
        public void Delete(Guid id)
        {
        }
    }
}
