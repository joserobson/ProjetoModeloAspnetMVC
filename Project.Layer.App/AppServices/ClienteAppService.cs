using Project.Layer.App.AppModels.Cliente;
using Project.Layer.App.Helper;
using Project.Layer.App.HttpServices;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Project.Layer.App.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        public IEnumerable<RelatorioClienteAppModel> GerarRelatorio()
        {
            var httpResponse = HttpServiceGlobal.ObterClientesParaRelatorio();

            if (!httpResponse.IsSuccessStatusCode)
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new System.Exception(erro);
            }

            var clientes = httpResponse.Content.ReadAsAsync<IEnumerable<RelatorioClienteAppModel>>().Result;
            return clientes;
        }
    }
}
