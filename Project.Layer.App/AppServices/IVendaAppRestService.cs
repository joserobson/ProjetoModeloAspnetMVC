using Project.Layer.App.AppModels.Venda;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface IVendaAppRestService
    {
        ResumoFinanceiroMensalAppModel ObterResumoFinanceiroMensal(string mesAno);

        ResumoDebitosAReceberAppModel ObterResumoDebitosAReceber(string dataReferencia);

        IEnumerable<ResumoVendasPorFuncionarioAppModel> ObterResumoDeVendasPorFuncionario(string dataInicio, string dataFim, string idFuncionario);

        ResumoPagamentosCaixaAppModel ObterResumoDosPagamentosEEntradasDoCaixa(string dataInicio, string dataFim);
    }
}
