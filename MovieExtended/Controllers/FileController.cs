using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var stream = new FileStream(fileEntity.FilePath.AbsolutePath, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        [Route("api/Files")]
        [HttpPost]
        public Guid Upload()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count != 1)
            {
                return Guid.Empty;
            }

            var file = httpRequest.Files.First() as string;
            var postedFile = httpRequest.Files[file];
            var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
            postedFile.SaveAs(filePath);
            var fileEntity = new File(null, new Uri(filePath), FileType.Track);
            var fileId = _session.Save(fileEntity);
            _session.Flush();
            return (Guid) fileId;
        }
    }
}
