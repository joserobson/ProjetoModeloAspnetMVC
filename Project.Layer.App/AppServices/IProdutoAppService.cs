using Project.Layer.App.AppModels.Produto;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface IProdutoAppService
    {
        IEnumerable<RelatorioProdutoAppModel> ObterRelatorioDeProdutos();
    }
}
