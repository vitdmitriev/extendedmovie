using System;
using System.Net.Http;
using System.Web.Http;

namespace MovieExtended.Controllers
{
    public class FileController : ApiController
    {
        [Route("api/File/{fileId}")]
        [HttpGet]
        public HttpMessageContent Download(Guid id)
        {
            return null;
        }

        [Route("api/File")]
        [HttpPost]
        public Guid Upload([FromBody]byte[] file)
        {
            return Guid.Empty;
        }
    }
}
