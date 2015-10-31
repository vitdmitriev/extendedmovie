using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using OriginalTrack.Models;

namespace OriginalTrack.Controllers.AndroidClient
{
    public class LanguageController : ApiController
    {
        [Route("api/Session/{sessionId}/Languages")]
        public IEnumerable<Language> GetLanguages(Guid sessionId)
        {
            
        }
    }
}
