using System.Collections.Generic;
using System.Net.Http;
using Project.Layer.App.AppModels.Produto;
using Project.Layer.App.Helper;

namespace Project.Layer.App.AppServices
{
    public class ProdutoAppService : IProdutoAppService
    {
        public IEnumerable<RelatorioProdutoAppModel> ObterRelatorioDeProdutos()
        {
            var httpResponse = HttpServices.HttpServiceEstoque.ObterRelatorioDeProdutos();

            if (!httpResponse.IsSuccessStatusCode)
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new System.Exception(erro);
            }

            var produtos = httpResponse.Content.ReadAsAsync<IEnumerable<RelatorioProdutoAppModel>>().Result;
            return produtos;
        }
    }
}
