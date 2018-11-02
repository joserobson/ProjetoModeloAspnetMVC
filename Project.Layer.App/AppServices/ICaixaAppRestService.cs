using Project.Layer.App.AppModels.Caixa;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface ICaixaAppRestService
    {
        IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(string diaFechamento);

        IEnumerable<MovimentoCaixaAppModel> ObterRetiradasDoCaixa(string diaFechamento);

        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows);

        int CountObterFechamentosDoDia(string filtroDia);
    }
}
