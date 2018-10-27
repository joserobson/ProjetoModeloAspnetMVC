using System.Collections.Generic;
using System.Linq;
using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;

namespace Project.Layer.Data.Repositories
{
    public class CaixaRepository : RepositorioBase<Caixa>, ICaixaRepository
    {
        public IEnumerable<Caixa> ObterFechamentos()
        {
            
            return this.GetAll().ToList().Select(c => new Caixa
            {
                CaixaInicioDoDia = c.CaixaInicioDoDia,
                DiaFechamento = c.DiaFechamento,                
                Funcionario = c.Funcionario,
                CaixaFinalDoDia = c.CaixaFinalDoDia,
                MovimentosDoCaixa = c.MovimentosDoCaixa,
                Id = c.Id,
                Retirada = c.Retirada,
                ValorDeEntrada = c.ValorDeEntrada,
                ValorDeSaida = c.ValorDeSaida,
                Saldo = c.Saldo
            }).ToList();
        }

        public IEnumerable<Caixa> ObterFechamentosDoDia(string diaFechamento)
        {
            return this.GetAll().Where(c=>c.DiaFechamento.Equals(diaFechamento))
                .ToList().Select(c => new Caixa
            {
                CaixaInicioDoDia = c.CaixaInicioDoDia,
                DiaFechamento = c.DiaFechamento,
                Funcionario = c.Funcionario,
                CaixaFinalDoDia = c.CaixaFinalDoDia,
                MovimentosDoCaixa = c.MovimentosDoCaixa,
                Id = c.Id,
                Retirada = c.Retirada,
                ValorDeEntrada = c.ValorDeEntrada,
                ValorDeSaida = c.ValorDeSaida,
                Saldo = c.Saldo
            }).ToList();
        }
    }
}
