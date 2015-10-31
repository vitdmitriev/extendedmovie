using System.Web;
using System.Web.Http;

namespace MovieExtended
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
