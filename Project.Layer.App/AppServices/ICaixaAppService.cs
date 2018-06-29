using Project.Layer.App.AppModels.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Layer.App.AppServices
{
    public interface ICaixaAppService
    {
        IEnumerable<FechamentoDiarioAppModel> ObterFechamentos();
    }
}
