using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Project.Layer.App.AppModels.Caixa;

namespace Project.Layer.App.AppServices
{
    public class CaixaAppService : ICaixaAppService
    {
        public IEnumerable<FechamentoDiarioAppModel> ObterFechamentos()
        {


            var fechamentos = new Collection<FechamentoDiarioAppModel>();

            for (int i = 0; i < 10; i++)
            {
                var fechamento = new FechamentoDiarioAppModel
                {
                    CaixaInicioDoDia = "R$ 10,00",
                    DiaFechamento = $"{i}/06/2018",
                    DinheiroEmCaixa = "R$ 50,00",
                    Funcionario = "Joao Victor",
                    Saldo = "-10,00",
                    Status = "Caixa Passando",
                    ValorDaRetirada = "R$ 20,00",
                    ValorDaSaida = "R$ 30,00",
                    ValorEntrada = "R$ 00,00",
                    Entradas = ObterEntradas(),
                    Saidas = ObterSaidas()
                };

                fechamentos.Add(fechamento);
            }


            return fechamentos;

        }

        private IEnumerable<MovimentoCaixaAppModel> ObterSaidas()
        {
            var saidas = new List<MovimentoCaixaAppModel>();

            saidas.Add(new MovimentoCaixaAppModel { Descricao = "Café", Valor = "R$ 5,00" });
            saidas.Add(new MovimentoCaixaAppModel { Descricao = "Almoço", Valor = "R$ 15,00" });

            return saidas;
        }

        private IEnumerable<MovimentoCaixaAppModel> ObterEntradas()
        {
            var entradas = new List<MovimentoCaixaAppModel>();

            entradas.Add(new MovimentoCaixaAppModel { Descricao = "PAg venda A Vista", Valor = "R$ 55,00" });
            entradas.Add(new MovimentoCaixaAppModel { Descricao = "Pag PArcela", Valor = "R$ 35,00" });

            return entradas;
        }
    
    }
}
