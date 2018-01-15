using ModeloAspNetMvc.App_Start;
using ModeloAspNetMvc.AutoMapper;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ModeloAspNetMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SimpleInjectorInitializer.Initialize();
            AutoMapperConfig.RegisterMappings();
        }

        protected void Application_Error()
        {
            Exception lastException = Server.GetLastError();
            Console.WriteLine(lastException.Message);
        }
    }
}
