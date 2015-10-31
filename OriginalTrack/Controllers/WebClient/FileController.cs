using System;
using System.Net.Http;
using System.Web.Http;

namespace OriginalTrack.Controllers.WebClient
{
    public class FileController : ApiController
    {
        // GET: api/File/5
        public HttpMessageContent Download(Guid id)
        {
            return null;
        }

        // POST: api/File
        public Guid Upload([FromBody]byte[] file)
        {
            return Guid.Empty;
        }
    }
}
