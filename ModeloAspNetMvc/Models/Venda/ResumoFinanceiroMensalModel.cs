using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Venda
{
    public class ResumoFinanceiroMensalModel
    {
        [Display(Name = "Mês/Ano")]
        public string FiltroMesAno { get; set; }


        public string ValorTotalEmVendas { get; set; }
        public string ValorDasVendasAVista { get; set; }
        public string ValorDasVendasAPrazo { get; set; }
        public string ValorTotalEmPagamentosRecebidos { get; set; }
        public string ValorTotalDosPagsRecebidosAVista { get; set; }
        public string ValorDosPagsRecebidosAVistaNoCartao { get; set; }
        public string ValorDosPagsRecebidosAVistaNoDinheiro { get; set; }
        public string ValorDosPagsRecebidosAVistaNoCheque { get; set; }
        public string ValorTotalEmPrestacoesRecebidas { get; set; }
        public string ValorDasPrestacoesRecebidasNoCartao { get; set; }
        public string ValorDasPrestacoesRecebidasNoCheque { get; set; }
        public string ValorDasPrestacoesRecebidasNoDinheiro { get; set; }
    }
}