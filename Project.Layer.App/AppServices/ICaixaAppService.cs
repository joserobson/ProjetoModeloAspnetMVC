using Project.Layer.App.AppModels.Caixa;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface ICaixaAppService
    {
        IEnumerable<FechamentoDiarioAppModel> ObterFechamentos();
        IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(int id);
        IEnumerable<MovimentoCaixaAppModel> ObterSaidasDoCaixa(int id);
        void CadastrarFechamentoDiario(FechamentoDiarioAppModel appServiceModel);
        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoDia(string diaFechamento);
    }
}
