using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Layer.Data.Repositories
{
    public class ResumoFinanceiroMensalRepository : RepositorioBase<ResumoFinanceiroMensal>, IResumoFinanceiroMensalRepository
    {
        public ResumoFinanceiroMensal ObterResumoMensal(string mesAno)
        {
            return this.GetAll().FirstOrDefault(r => r.MesAnoReferencia.Equals(mesAno));
        }
    }
}
