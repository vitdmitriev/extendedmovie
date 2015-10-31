using System;
using System.Web;
using System.Web.Http;
using NHibernate;

namespace MovieExtended
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var sessionObject = HttpContext.Current.Items[PerRequestLifetimeManager.Key];
            var currentSession = sessionObject as ISession;
            if (currentSession != null)
            {
                currentSession.Close();
            }
        }
    }
}
