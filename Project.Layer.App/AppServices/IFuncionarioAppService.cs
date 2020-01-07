using Project.Layer.App.AppModels.Funcionario;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface IFuncionarioAppService
    {

        IEnumerable<FuncionarioAppModel> ObterTodosOsFuncionarios();
    }
}
