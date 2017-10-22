using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using ViaRepairFTE.Services;

namespace ViaRepairFTE
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AppointmentService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}