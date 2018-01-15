using ComFacil.FrenteCaixa.Common.HelperHttpService;
using Project.Layer.App.AppModels.Cliente;
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
            var httpResponse = HttpServiceGlobal.ObterClientes("PAU");

            if (!httpResponse.IsSuccessStatusCode)
            {
                var erro = HelperHttpService.ObterMensagemHttpResponse(httpResponse);
                throw new System.Exception(erro);
            }

            var clientes = httpResponse.Content.ReadAsAsync<IEnumerable<ClienteAppModel>>().Result;

            return clientes.Select(c => new RelatorioClienteAppModel
            {
                NomeDoCliente = c.Nome,
                NumeroDaFicha = c.CodigoFicha
            }).ToList();

        }
    }
}
