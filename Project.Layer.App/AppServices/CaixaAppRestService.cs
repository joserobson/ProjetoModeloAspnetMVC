using System.Collections.Generic;
using System.Net.Http;
using Project.CrossCutting.Exceptions;
using Project.Layer.App.AppModels.Caixa;
using Project.Layer.App.Helper;

namespace Project.Layer.App.AppServices
{
    public class CaixaAppRestService : ICaixaAppRestService
    {

        public IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows)
        {
            IEnumerable<FechamentoDiarioAppModel> entradas = new List<FechamentoDiarioAppModel>();

            var httpResponse = HttpServices.HttpServiceCaixa.ObterFechamentos(currentPage, maxRows, diaFechamento);
            if (httpResponse.IsSuccessStatusCode)
            {
                entradas = httpResponse.Content.ReadAsAsync<IEnumerable<FechamentoDiarioAppModel>>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return entradas;
        }


        public IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(string diaFechamento)
        {
            IEnumerable<MovimentoCaixaAppModel> entradas = new List<MovimentoCaixaAppModel>();

            var httpResponse = HttpServices.HttpServiceCaixa.ObterEntradasDoDia(diaFechamento);
            if (httpResponse.IsSuccessStatusCode)
            {
                entradas = httpResponse.Content.ReadAsAsync<IEnumerable<MovimentoCaixaAppModel>>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return entradas;
        }


        public IEnumerable<MovimentoCaixaAppModel> ObterRetiradasDoCaixa(string diaFechamento)
        {
            IEnumerable<MovimentoCaixaAppModel> entradas = new List<MovimentoCaixaAppModel>();

            var httpResponse = HttpServices.HttpServiceCaixa.ObterRetiradasDoDia(diaFechamento);
            if (httpResponse.IsSuccessStatusCode)
            {
                entradas = httpResponse.Content.ReadAsAsync<IEnumerable<MovimentoCaixaAppModel>>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return entradas;
        }

        public int CountObterFechamentosDoDia(string filtroDia)
        {
            int count = 0;

            var httpResponse = HttpServices.HttpServiceCaixa.ObterCountFechamentos(filtroDia);
            if (httpResponse.IsSuccessStatusCode)
            {
                count = httpResponse.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return count;
        }
    }
}
