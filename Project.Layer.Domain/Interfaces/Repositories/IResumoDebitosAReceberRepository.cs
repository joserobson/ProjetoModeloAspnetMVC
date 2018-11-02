using Project.Layer.Domain.Entities;

namespace Project.Layer.Domain.Interfaces.Repositories
{
    public interface IResumoDebitosAReceberRepository: IRepository<ResumoDebitosAReceber>
    {
        ResumoDebitosAReceber ObterResumoDebitoAReceber(string dataReferencia);
    }
}
