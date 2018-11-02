using Project.Layer.App.AppModels.Venda;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface IVendaAppService
    {
        ResumoFinanceiroMensalAppModel ObterResumoFinanceiroMensal(string mesAno);

        void CadastrarResumosFinanceiros(IEnumerable<ResumoFinanceiroMensalAppModel> resumosAppModel);

        ResumoDebitosAReceberAppModel ObterResumoDebitosAReceber(string dataReferencia);

        void CadastrarResumoDebitosAReceber(IEnumerable<ResumoDebitosAReceberAppModel> debitosAReceber);
    }
}
