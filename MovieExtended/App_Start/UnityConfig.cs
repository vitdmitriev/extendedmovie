using Microsoft.Practices.Unity;
using System.Web.Http;
using NHibernate;
using Unity.WebApi;

namespace MovieExtended
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<ISessionFactory>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(c => SessionFactoryConfig
                    .CreateSessionFactory()));
            container.RegisterType<ISession>(
                new PerRequestLifetimeManager(),
                new InjectionFactory(
                    c => c.Resolve<ISessionFactory>().OpenSession()));
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}