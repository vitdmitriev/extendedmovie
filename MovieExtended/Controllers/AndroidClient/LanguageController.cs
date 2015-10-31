using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieExtended.Models;

namespace MovieExtended.Controllers.AndroidClient
{
    public class LanguageController : ApiController
    {
        [Route("api/Session/{sessionId}/Languages")]
        [HttpGet]
        public IEnumerable<Language> GetLanguages(Guid sessionId)
        {
            return null;
        }
    }
}
