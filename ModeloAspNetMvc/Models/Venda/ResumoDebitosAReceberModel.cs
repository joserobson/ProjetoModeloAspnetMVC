using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Venda
{
    public class ResumoDebitosAReceberModel
    {
        [Display(Name = "Total em Débitos Retroativos")]
        public string TotalEmDebitosRetroativos { get; set; }

        [Display(Name = "Total em Débitos Para Receber")]
        public string TotalEmDebitosAReceber { get; set; }

        [Display(Name = "Data de Referência")]
        public string FiltroDataReferencia { get; set; }

        [Display(Name = "Valor Total")]
        public string ValorTotal { get; set; }
    }
}