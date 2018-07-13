using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Caixa
{
    public class FechamentoDiarioModel
    {
        public int Id { get; set; }

        [Display(Name ="Data")]
        public string DiaFechamento { get; set; }

        [Display(Name = "Início do Dia")]
        public string CaixaInicioDoDia { get; set; }

        [Display(Name = "Entrada")]
        public string ValorEntrada { get; set; }

        [Display(Name = "Saída")]
        public string ValorDaSaida { get; set; }

        [Display(Name = "Retirada")]
        public string ValorDaRetirada { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Funcionário")]
        public string Funcionario { get; set; }

        [Display(Name = "Final do Dia")]
        public string CaixaFinalDoDia { get; set; }

        [Display(Name = "Saldo")]
        public string Saldo { get; set; }

        public IEnumerable<MovimentoCaixaModel> Entradas { get; set; }
        public IEnumerable<MovimentoCaixaModel> Saidas { get; set; }

    }
}