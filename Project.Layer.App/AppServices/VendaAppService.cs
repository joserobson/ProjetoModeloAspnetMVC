using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Project.Layer.App.AppModels.Venda;
using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;
using System;

namespace Project.Layer.App.AppServices
{
    public class VendaAppService : IVendaAppService
    {

        private readonly IResumoFinanceiroMensalRepository _resumoFinanceiroMensalRepository;
        private readonly IResumoDebitosAReceberRepository _resumoDebitosAReceberRepository;

        public VendaAppService(IResumoFinanceiroMensalRepository resumoFinanceiroMensalRepository, IResumoDebitosAReceberRepository resumoDebitosAReceberRepository)
        {
            _resumoFinanceiroMensalRepository = resumoFinanceiroMensalRepository;
            _resumoDebitosAReceberRepository = resumoDebitosAReceberRepository;
        }               

        public void CadastrarResumosFinanceiros(IEnumerable<ResumoFinanceiroMensalAppModel> resumosAppModel)
        {
            ResumoFinanceiroMensal resumoMensal = null;

            foreach (var itemResumo in resumosAppModel)
            {

                resumoMensal = Mapper.Map<ResumoFinanceiroMensal>(itemResumo);

                var resumoEmBanco = _resumoFinanceiroMensalRepository.Get(r => r.MesAnoReferencia == itemResumo.MesAnoReferencia).FirstOrDefault();

                if(resumoEmBanco != null)
                {
                    resumoEmBanco.ValorDasPrestacoesRecebidasNoCartao = resumoMensal.ValorDasPrestacoesRecebidasNoCartao;
                    resumoEmBanco.ValorDasPrestacoesRecebidasNoCheque = resumoMensal.ValorDasPrestacoesRecebidasNoCheque;
                    resumoEmBanco.ValorDasPrestacoesRecebidasNoDinheiro = resumoMensal.ValorDasPrestacoesRecebidasNoCartao;
                    resumoEmBanco.ValorDasVendasAPrazo = resumoMensal.ValorDasVendasAPrazo;
                    resumoEmBanco.ValorDasVendasAVista = resumoMensal.ValorDasVendasAVista;
                    resumoEmBanco.ValorDosPagsRecebidosAVistaNoCartao = resumoMensal.ValorDosPagsRecebidosAVistaNoCartao;
                    resumoEmBanco.ValorDosPagsRecebidosAVistaNoCheque = resumoMensal.ValorDosPagsRecebidosAVistaNoCheque;
                    resumoEmBanco.ValorDosPagsRecebidosAVistaNoDinheiro = resumoMensal.ValorDosPagsRecebidosAVistaNoDinheiro;
                    resumoEmBanco.ValorTotalDosPagsRecebidosAVista = resumoMensal.ValorTotalDosPagsRecebidosAVista;
                    resumoEmBanco.ValorTotalEmPagamentosRecebidos = resumoMensal.ValorTotalEmPagamentosRecebidos;
                    resumoEmBanco.ValorTotalEmPrestacoesRecebidas = resumoMensal.ValorTotalEmPrestacoesRecebidas;
                    resumoEmBanco.ValorTotalEmVendas = resumoMensal.ValorTotalEmVendas;
                }
                else
                {
                    _resumoFinanceiroMensalRepository.Adicionar(resumoMensal);
                }
                
            }

            _resumoFinanceiroMensalRepository.SalvarTodos();
        }        

        public ResumoFinanceiroMensalAppModel ObterResumoFinanceiroMensal(string mesAno)
        {
            var resumoModel = _resumoFinanceiroMensalRepository.GetAll().FirstOrDefault(r => r.MesAnoReferencia.Equals(mesAno));
            return Mapper.Map<ResumoFinanceiroMensalAppModel>(resumoModel);         
        }

        public ResumoDebitosAReceberAppModel ObterResumoDebitosAReceber(string dataReferencia)
        {

            var resumoModel = _resumoDebitosAReceberRepository.ObterResumoDebitoAReceber(dataReferencia);
            return Mapper.Map<ResumoDebitosAReceberAppModel>(resumoModel);            
        }

        public void CadastrarResumoDebitosAReceber(IEnumerable<ResumoDebitosAReceberAppModel> debitosAReceber)
        {
            ResumoDebitosAReceber resumoMensal = null;

            foreach (var itemResumo in debitosAReceber)
            {

                resumoMensal = Mapper.Map<ResumoDebitosAReceber>(itemResumo);

                var resumoEmBanco = _resumoDebitosAReceberRepository.Get(r => r.DataReferencia == itemResumo.DataReferencia).FirstOrDefault();

                if (resumoEmBanco != null)
                {
                    resumoEmBanco.ValorAReceber = resumoMensal.ValorAReceber;
                    resumoEmBanco.ValorRetroativo = resumoMensal.ValorRetroativo;
                }
                else
                {
                    _resumoDebitosAReceberRepository.Adicionar(resumoMensal);
                }

            }

            _resumoDebitosAReceberRepository.SalvarTodos();
        }
    }
}
