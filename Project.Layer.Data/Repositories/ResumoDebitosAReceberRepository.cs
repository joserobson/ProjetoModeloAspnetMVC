using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Layer.Data.Repositories
{
    public class ResumoDebitosAReceberRepository : RepositorioBase<ResumoDebitosAReceber>, IResumoDebitosAReceberRepository
    {
        public ResumoDebitosAReceber ObterResumoDebitoAReceber(string dataReferencia)
        {
            return this.GetAll().FirstOrDefault(r => r.DataReferencia.Equals(dataReferencia));
        }
    }
}
