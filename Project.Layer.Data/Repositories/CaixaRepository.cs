﻿using System.Collections.Generic;
using System.Linq;
using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;

namespace Project.Layer.Data.Repositories
{
    public class CaixaRepository : RepositorioBase<Caixa>, ICaixaRepository
    {
        public IEnumerable<Caixa> ObterFechamentos(int currentPage, int maxRows)
        {
            return this.GetAll().Where(c => !string.IsNullOrEmpty(c.Funcionario))
                .OrderByDescending(c => c.Id).Skip((currentPage - 1) * maxRows).Take(maxRows)
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

        public IEnumerable<Caixa> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows)
        {
            return this.GetAll().Where(c => c.DiaFechamento.Equals(diaFechamento) && !string.IsNullOrEmpty(c.Funcionario))
                .OrderByDescending(c => c.Id).Skip((currentPage - 1) * maxRows).Take(maxRows)
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

        public int CountObterFechamentosDoDia(string diaFechamento)
        {
            return this.GetAll().Count(c => c.DiaFechamento.Equals(diaFechamento));
        }

        public int CountObterFechamentos()
        {
            return this.GetAll().Count();
        }

        public IEnumerable<Caixa> ObterFechamentosDoMes(string mesAno)
        {
            return this.GetAll().Where(c => !string.IsNullOrEmpty(c.Funcionario))
                .Where(c=>c.DiaFechamento.Substring(3,7).Equals(mesAno)).OrderByDescending(c => c.Id)
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
