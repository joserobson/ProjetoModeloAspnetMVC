using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Venda
{
    public class ResumoPagamentoCaixaModel
    {

        [Display(Name = "De")]
        public string DataInicio { get; set; }

        [Display(Name = "Até")]
        public string DataFim { get; set; }

        [Display(Name = "Soma das Entradas No Caixa")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaDeTodasAsEntradasNoCaixa { get; set; }

        [Display(Name = "Qtd de Entradas No Caixa")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal QtdDeTodasAsEntradasNoCaixa { get; set; }

        [Display(Name = "Soma das Entradas Início do Dia")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaDasEntradasInicioDoDia { get; set; }

        [Display(Name = "Qtd das Entradas Início do Dia")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal QtdEntradasInicioDoDia { get; set; }

        [Display(Name = "Total que Entrou no Caixa")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaQueEntrouNoCaixa { get; set; }

        [Display(Name = "Total Dos Pagamentos")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaDosPagamentos { get; set; }

        [Display(Name = "Qtd de Pagamentos")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal QtdDePagamentos { get; set; }

        [Display(Name = "Soma dos Pagamentos no Cartão")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaDosPagamentosNoCartao { get; set; }

        [Display(Name = "Qtd de Pagamentos no Cartão")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal QtdPagamentosNoCartao { get; set; }

        [Display(Name = "Soma dos Pagamentos em Dinheiro")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaDosPagamentosEmDinheiro { get; set; }

        [Display(Name = "Soma dos Pagamentos à Prazo")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaDosPagamentosAPrazo { get; set; }

        [Display(Name = "Qtd Pagamentos à Prazo")]
        public int QtdPagamentosAPrazo { get; set; }        

        [Display(Name = "Qtd de Pagamentos à Vista")]        
        public int QtdPagamentosAVista { get; set; }

        [Display(Name = "Soma dos Pagamentos à Vista")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SomaDosPagamentosAVista { get; set; }

        [Display(Name = "Diferência entre Caixa e Pagamentos")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DiferencaEntreCaixaEpagamento { get; set; }

        //public IEnumerable<CaixaEntradaAppModel> EntradasNoCaixaSemPagamento { get; set; }
        [Display(Name = "Observação")]
        public string ConclusaoAposConferencia { get; set; }
        
        
        
    }
}