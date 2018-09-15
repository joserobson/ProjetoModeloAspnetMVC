using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Project.Layer.App.AppModels.Venda;
using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;

namespace Project.Layer.App.AppServices
{
    public class VendaAppService : IVendaAppService
    {

        private readonly IResumoFinanceiroMensalRepository _resumoFinanceiroMensalRepository;

        public VendaAppService(IResumoFinanceiroMensalRepository resumoFinanceiroMensalRepository)
        {
            _resumoFinanceiroMensalRepository = resumoFinanceiroMensalRepository;
        }

        public void CadastrarResumosFinanceiros(IEnumerable<ResumoFinanceiroMensalAppModel> resumosAppModel)
        {
            ResumoFinanceiroMensal resumoMensal = null;

            foreach (var itemResumo in resumosAppModel)
            {

                resumoMensal = Mapper.Map<ResumoFinanceiroMensal>(itemResumo);

                _resumoFinanceiroMensalRepository.Adicionar(resumoMensal);
            }

            _resumoFinanceiroMensalRepository.SalvarTodos();
        }

        public ResumoFinanceiroMensalAppModel ObterResumoFinanceiroMensal(string mesAno)
        {
            var resumoModel = _resumoFinanceiroMensalRepository.GetAll().FirstOrDefault(r => r.MesAno.Equals(mesAno));

            return Mapper.Map<ResumoFinanceiroMensalAppModel>(resumoModel);
        }
    }
}
