using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MovieExtended.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Util;
using File = MovieExtended.Models.File;

namespace MovieExtended.Controllers
{
    public class FileController : ApiController
    {
        private readonly ISession _session;

        public FileController(ISession session)
        {
            _session = session;
        }

        [Route("api/Files/{fileId}")]
        [HttpGet]
        public HttpResponseMessage Download(Guid fileId)
        {
            var fileEntity = _session.Query<File>().SingleOrDefault(file => file.Id == fileId);
            if (fileEntity == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(fileEntity.FilePath.LocalPath, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        [Route("api/Files")]
        [HttpPost]
        public async Task<Guid> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var file = provider.Contents.FirstOrDefault();
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();
            var filePath = HttpContext.Current.Server.MapPath("~/" + filename);
            System.IO.File.WriteAllBytes(filePath, buffer);
            var fileEntity = new File(null, new Uri(filePath), FileType.Track);
            var fileId = _session.Save(fileEntity);
            _session.Flush();
            return (Guid) fileId;
        }
    }
}
