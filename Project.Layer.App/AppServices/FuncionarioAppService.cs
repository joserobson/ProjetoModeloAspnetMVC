using System.Collections.Generic;
using System.Net.Http;
using Project.Layer.App.AppModels.Funcionario;
using Project.Layer.App.Helper;
using Project.Layer.App.HttpServices;

namespace Project.Layer.App.AppServices
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        public IEnumerable<FuncionarioAppModel> ObterTodosOsFuncionarios()
        {
            var httpResponse = HttpServiceGlobal.ObterTodosOsFuncionarios();

            if (!httpResponse.IsSuccessStatusCode)
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new System.Exception(erro);
            }

            var funcionarios = httpResponse.Content.ReadAsAsync<IEnumerable<FuncionarioAppModel>>().Result;

            return funcionarios;                       
        }
    }
}
