using Project.Layer.Domain.Entities;
using System.Collections.Generic;

namespace Project.Layer.Domain.Interfaces.Repositories
{
    public interface ICaixaRepository: IRepository<Caixa>
    {
        IEnumerable<Caixa> ObterFechamentos();

        IEnumerable<Caixa> ObterFechamentosDoDia(string diaFechamento);
    }
}
