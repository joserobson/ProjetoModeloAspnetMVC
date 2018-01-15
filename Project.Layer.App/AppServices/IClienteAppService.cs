using Project.Layer.App.AppModels.Cliente;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface IClienteAppService
    {
        IEnumerable<RelatorioClienteAppModel> GerarRelatorio();
    }
}
