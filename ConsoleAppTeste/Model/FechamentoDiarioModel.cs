using System.Collections.Generic;

namespace ConsoleAppTeste.Model
{
    public class FechamentoDiarioModel
    {
        public int Id { get; set; }

        public string DiaFechamento { get; set; }        
        public string CaixaInicioDoDia { get; set; }
        public string CaixaFinalDoDia { get; set; }
        public string ValorEntrada { get; set; }        
        public string ValorDaSaida { get; set; }        
        public string ValorDaRetirada { get; set; }        
        public string Status { get; set; }        
        public string Funcionario { get; set; }                    
        public string Saldo { get; set; }

        public IEnumerable<MovimentoCaixaModel> Entradas { get; set; }
        public IEnumerable<MovimentoCaixaModel> Saidas { get; set; }
    }
}
