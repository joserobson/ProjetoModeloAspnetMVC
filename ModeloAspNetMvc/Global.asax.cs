using ModeloAspNetMvc.App_Start;
using ModeloAspNetMvc.AutoMapper;
using System;
using System.Web.Http;
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

            SimpleInjectorInitializer.Initialize();

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            AutoMapperConfig.RegisterMappings();
           
            GlobalConfiguration.Configuration.EnsureInitialized();

        }

        protected void Application_Error()
        {
            Exception lastException = Server.GetLastError();
            Console.WriteLine(lastException.Message);
        }
    }
}
