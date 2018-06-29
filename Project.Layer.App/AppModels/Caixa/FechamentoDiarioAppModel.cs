using System.Collections.Generic;

namespace Project.Layer.App.AppModels.Caixa
{
    public class FechamentoDiarioAppModel
    {
        public string DiaFechamento { get; set; }
        public string CaixaInicioDoDia { get; set; }
        public string ValorEntrada { get; set; }
        public string ValorDaSaida { get; set; }
        public string ValorDaRetirada { get; set; }
        public string Status { get; set; }
        public string Funcionario { get; set; }
        public string DinheiroEmCaixa { get; set; }

        public string Saldo { get; set; }

        public IEnumerable<MovimentoCaixaAppModel> Entradas { get; set; }
        public IEnumerable<MovimentoCaixaAppModel> Saidas { get; set; }
    }
}
