using System;
using System.Net.Http;
using System.Web.Http;

namespace OriginalTrack.Controllers
{
    public class FileController : ApiController
    {
        [Route("api/File/{fileId}")]
        public HttpMessageContent Download(Guid id)
        {
            return null;
        }

        [Route("api/File")]
        public Guid Upload([FromBody]byte[] file)
        {
            return Guid.Empty;
        }
    }
}
