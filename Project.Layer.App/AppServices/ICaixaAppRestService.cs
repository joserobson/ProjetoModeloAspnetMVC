using Project.Layer.App.AppModels.Caixa;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface ICaixaAppRestService
    {
        IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(int id);

        IEnumerable<MovimentoCaixaAppModel> ObterRetiradasDoCaixa(int id);

        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows);

        int CountObterFechamentosDoDia(string filtroDia);
    }
}
