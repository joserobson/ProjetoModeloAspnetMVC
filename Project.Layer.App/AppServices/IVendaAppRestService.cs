using Project.Layer.App.AppModels.Venda;

namespace Project.Layer.App.AppServices
{
    public interface IVendaAppRestService
    {
        ResumoFinanceiroMensalAppModel ObterResumoFinanceiroMensal(string mesAno);

        ResumoDebitosAReceberAppModel ObterResumoDebitosAReceber(string dataReferencia);
    }
}
