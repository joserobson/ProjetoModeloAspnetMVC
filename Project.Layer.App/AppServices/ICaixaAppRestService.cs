using Project.Layer.App.AppModels.Caixa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Layer.App.AppServices
{
    public interface ICaixaAppRestService
    {
        IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(string diaFechamento);

        IEnumerable<MovimentoCaixaAppModel> ObterRetiradasDoCaixa(string diaFechamento);

        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows);

        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoMes(string mesAno);

        Task<IEnumerable<FechamentoDiarioAppModel>> ObterFechamentosDoMesAsync(string mesAno);

        Task<IEnumerable<FechamentoDiarioAppModel>> ObterFechamentosDoDiaAsync(string diaFechamento, int currentPage, int maxRows);

        int CountObterFechamentosDoDia(string filtroDia);
    }
}
