using Project.CrossCutting.Ioc;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace ModeloAspNetMvc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {            

            config.MapHttpAttributeRoutes();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DIContainer.container);
                
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
