using System.Net.Http;
using Project.CrossCutting.Exceptions;
using Project.Layer.App.AppModels.Venda;
using Project.Layer.App.Helper;

namespace Project.Layer.App.AppServices
{
    public class VendaAppRestService : IVendaAppRestService
    {
        public ResumoDebitosAReceberAppModel ObterResumoDebitosAReceber(string dataReferencia)
        {
            ResumoDebitosAReceberAppModel resumo = null;

            var httpResponse = HttpServices.HttpServiceVenda.ObterDebitosDosClientesAReceber(dataReferencia);
            if (httpResponse.IsSuccessStatusCode)
            {
                resumo = httpResponse.Content.ReadAsAsync<ResumoDebitosAReceberAppModel>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return resumo;
        }

        public ResumoFinanceiroMensalAppModel ObterResumoFinanceiroMensal(string mesAno)
        {
            ResumoFinanceiroMensalAppModel resumo = null;

            var httpResponse = HttpServices.HttpServiceVenda.ObterResumoFinanceiroDoMes(mesAno);
            if (httpResponse.IsSuccessStatusCode)
            {
                resumo = httpResponse.Content.ReadAsAsync<ResumoFinanceiroMensalAppModel>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return resumo;
        }
    }
}
