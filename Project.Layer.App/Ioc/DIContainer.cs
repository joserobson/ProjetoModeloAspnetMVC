using Project.Layer.App.AppServices;
using SimpleInjector;

namespace Project.Layer.App.Ioc
{
    public class DIContainer
    {
        public static Container container;

        public static void RegisterDependencies(Container containerToInject)
        {
            containerToInject.Register<IClienteAppService, ClienteAppService>();
        }
    }
}
