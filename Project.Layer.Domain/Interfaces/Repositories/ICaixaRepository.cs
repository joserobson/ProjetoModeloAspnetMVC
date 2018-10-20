using Project.Layer.Domain.Entities;
using System.Collections.Generic;

namespace Project.Layer.Domain.Interfaces.Repositories
{
    public interface ICaixaRepository: IRepository<Caixa>
    {
        IEnumerable<Caixa> ObterFechamentos(int currentPage, int maxRows);

        IEnumerable<Caixa> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows);

        int CountObterFechamentosDoDia(string diaFechamento);

        int CountObterFechamentos();
    }
}
