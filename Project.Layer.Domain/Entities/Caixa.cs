using System.Collections.Generic;

namespace Project.Layer.Domain.Entities
{
    public class Caixa: BaseEntity
    {
        public string CaixaInicioDoDia { get; set; }

        public string DiaFechamento { get; set; }        

        public string ValorDeEntrada { get; set; }

        public string ValorDeSaida { get; set; }

        public string Retirada { get; set; }        

        public string Funcionario { get; set; }

        public string CaixaFinalDoDia { get; set; }

        public string Saldo { get; set; }

        public virtual ICollection<MovimentoDoCaixa> MovimentosDoCaixa { get; set; }
    }
}
