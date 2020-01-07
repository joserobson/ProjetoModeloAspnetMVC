using Project.Layer.App.AppServices;
using Project.Layer.Data.Contexto;
using Project.Layer.Data.Repositories;
using Project.Layer.Domain.Interfaces.Repositories;
using SimpleInjector;

namespace Project.CrossCutting.Ioc
{
    public class DIContainer
    {
        public static Container container;

        public static void RegisterDependencies(Container containerToInject)
        {
            containerToInject.Register<ProjectContext>(Lifestyle.Scoped);

            containerToInject.Register<IClienteAppService, ClienteAppService>();
            containerToInject.Register<ICaixaAppService, CaixaAppService>();
            containerToInject.Register<IVendaAppService, VendaAppService>();
            containerToInject.Register<ICaixaAppRestService, CaixaAppRestService>();
            containerToInject.Register<IVendaAppRestService, VendaAppRestService>();
            containerToInject.Register<IFuncionarioAppService, FuncionarioAppService>();

            containerToInject.Register<IResumoDebitosAReceberRepository, ResumoDebitosAReceberRepository>(Lifestyle.Scoped);
            containerToInject.Register<IResumoFinanceiroMensalRepository, ResumoFinanceiroMensalRepository>(Lifestyle.Scoped);
            containerToInject.Register<ICaixaRepository, CaixaRepository>(Lifestyle.Scoped);
        }
    }
}
