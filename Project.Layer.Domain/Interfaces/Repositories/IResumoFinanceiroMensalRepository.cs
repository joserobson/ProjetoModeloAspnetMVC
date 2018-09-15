using Project.Layer.Domain.Entities;

namespace Project.Layer.Domain.Interfaces.Repositories
{
    public interface IResumoFinanceiroMensalRepository : IRepository<ResumoFinanceiroMensal>
    {
        ResumoFinanceiroMensal ObterResumoMensal(string mesAno);
    }
}
