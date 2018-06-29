using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModeloAspNetMvc.Models.Caixa
{
    public class FechamentoDiarioModel
    {
        [Display(Name ="Dia do Fechamento")]
        public string DiaFechamento { get; set; }

        [Display(Name = "Caixa Início do Dia")]
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

        [Display(Name = "Caixa Final do Dia")]
        public string DinheiroEmCaixa { get; set; }

        [Display(Name = "Saldo")]
        public string Saldo { get; set; }

        public IEnumerable<MovimentoCaixaModel> Entradas { get; set; }
        public IEnumerable<MovimentoCaixaModel> Saidas { get; set; }

    }
}