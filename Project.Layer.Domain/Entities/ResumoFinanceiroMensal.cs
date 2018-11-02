namespace Project.Layer.Domain.Entities
{
    public class ResumoFinanceiroMensal: BaseEntity
    {
        public decimal ValorTotalEmVendas { get; set; }
        public decimal ValorDasVendasAVista { get; set; }
        public decimal ValorDasVendasAPrazo { get; set; }

        public decimal ValorTotalEmPagamentosRecebidos { get; set; }

        public decimal ValorTotalDosPagsRecebidosAVista { get; set; }
        public decimal ValorDosPagsRecebidosAVistaNoCartao { get; set; }
        public decimal ValorDosPagsRecebidosAVistaNoDinheiro { get; set; }
        public decimal ValorDosPagsRecebidosAVistaNoCheque { get; set; }


        public decimal ValorTotalEmPrestacoesRecebidas { get; set; }
        public decimal ValorDasPrestacoesRecebidasNoCartao { get; set; }
        public decimal ValorDasPrestacoesRecebidasNoCheque { get; set; }
        public decimal ValorDasPrestacoesRecebidasNoDinheiro { get; set; }

        public string MesAnoReferencia { get; set; }
    }
}
