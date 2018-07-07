using Project.CrossCutting.Ioc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace ModeloAspNetMvc.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            DIContainer.container = new Container();
            DIContainer.container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(DIContainer.container);

            DIContainer.container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DIContainer.container.RegisterWebApiControllers(GlobalConfiguration.Configuration, Assembly.GetExecutingAssembly());

            DIContainer.container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(DIContainer.container));
            
        }

        private static void InitializeContainer(Container container)
        {           
            DIContainer.RegisterDependencies(container);
        }
    }
}