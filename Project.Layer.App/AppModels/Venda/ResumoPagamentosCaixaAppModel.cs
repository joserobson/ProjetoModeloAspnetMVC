using Project.Layer.App.AppModels.Caixa;
using System.Collections.Generic;

namespace Project.Layer.App.AppModels.Venda
{
    public class ResumoPagamentosCaixaAppModel
    {
        public decimal SomaDeTodasAsEntradasNoCaixa { get; set; }
        public decimal QtdDeTodasAsEntradasNoCaixa { get; set; }
        public decimal SomaDasEntradasInicioDoDia { get; set; }
        public decimal QtdEntradasInicioDoDia { get; set; }
        public decimal SomaDosPagamentos { get; set; }
        public decimal QtdDePagamentos { get; set; }
        public decimal SomaDosPagamentosNoCartao { get; set; }
        public decimal QtdPagamentosNoCartao { get; set; }


        public decimal DiferencaEntreCaixaEpagamento { get; set; }

        public IEnumerable<CaixaEntradaAppModel> EntradasNoCaixaSemPagamento { get; set; }

        public string ConclusaoAposConferencia { get; set; }
        public decimal SomaQueEntrouNoCaixa { get; set; }
        public decimal SomaDosPagamentosEmDinheiro { get; set; }
        public int QtdPagamentosAPrazo { get; set; }
        public int QtdPagamentosAVista { get; set; }
        public decimal SomaDosPagamentosAVista { get; set; }
        public decimal SomaDosPagamentosAPrazo { get; set; }
    }
}
