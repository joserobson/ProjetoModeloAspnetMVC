using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Project.Layer.App.AppModels.Caixa;
using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Enums;
using Project.Layer.Domain.Interfaces.Repositories;

namespace Project.Layer.App.AppServices
{
    public class CaixaAppService : ICaixaAppService
    {
        private readonly ICaixaRepository _caixaRepository;


        public CaixaAppService(ICaixaRepository caixaRepository)
        {
            this._caixaRepository = caixaRepository;
        }

        public IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows)
        {
            var fechamentos = this._caixaRepository.ObterFechamentosDoDia(diaFechamento, currentPage, maxRows);

            if (!fechamentos.Any())
            {
                return new List<FechamentoDiarioAppModel>();
            }

            return fechamentos.Select(f => new FechamentoDiarioAppModel
            {
                Id = f.Id,
                CaixaInicioDoDia = f.CaixaInicioDoDia,
                DiaFechamento = f.DiaFechamento,
                CaixaFinalDoDia = f.CaixaFinalDoDia,
                Funcionario = f.Funcionario,
                ValorDaRetirada = f.Retirada,
                ValorDaSaida = f.ValorDeSaida,
                ValorEntrada = f.ValorDeEntrada,
                Saldo = f.Saldo,
                Status = StatusCaixa(f.Saldo)
            }).ToList();
        }

        public string StatusCaixa(string saldoParam)
        {

            var saldoRemoverCifrao = saldoParam.Replace("R$", "").Trim();
            var saldoRemoverEspacos = saldoRemoverCifrao.Replace(" ", string.Empty).Trim();

            var saldo = float.Parse(saldoRemoverEspacos);

            if (saldo == 0)
            {
                return "Caixa Fechado";
            }

            return saldo > 0 ? "Caixa Passando" : "Caixa Faltando";
        }

        public IEnumerable<FechamentoDiarioAppModel> ObterFechamentosComDetalhes()
        {

            var fechamentos = this._caixaRepository.ObterFechamentos(1, 2000);

            if (!fechamentos.Any())
            {
                return new List<FechamentoDiarioAppModel>();
            }

            return fechamentos.Select(f => new FechamentoDiarioAppModel
            {
                Id = f.Id,
                CaixaInicioDoDia = f.CaixaInicioDoDia,
                DiaFechamento = f.DiaFechamento,
                CaixaFinalDoDia = f.CaixaFinalDoDia,
                Funcionario = f.Funcionario,
                ValorDaRetirada = f.Retirada,
                ValorDaSaida = f.ValorDeSaida,
                ValorEntrada = f.ValorDeEntrada,
                Saldo = f.Saldo,
                Status = StatusCaixa(f.Saldo),
                Entradas = Mapper.Map<IEnumerable<MovimentoCaixaAppModel>>(f.MovimentosDoCaixa.Where(m => m.TipoMovimentoCaixa == (int)ETipoMovimentoCaixa.Entrada)),
                Saidas = Mapper.Map<IEnumerable<MovimentoCaixaAppModel>>(f.MovimentosDoCaixa.Where(m => m.TipoMovimentoCaixa == (int)ETipoMovimentoCaixa.Saida))

            }).OrderByDescending(c => DateTime.Parse(c.DiaFechamento)).ToList();
        }

        public IEnumerable<FechamentoDiarioAppModel> ObterFechamentos(int currentPage, int maxRows)
        {

            var fechamentos = this._caixaRepository.ObterFechamentos(currentPage, maxRows);

            if (!fechamentos.Any())
            {
                return new List<FechamentoDiarioAppModel>();
            }

            return fechamentos.Select(f => new FechamentoDiarioAppModel
            {
                Id = f.Id,
                CaixaInicioDoDia = f.CaixaInicioDoDia,
                DiaFechamento = f.DiaFechamento,
                CaixaFinalDoDia = f.CaixaFinalDoDia,
                Funcionario = f.Funcionario,
                ValorDaRetirada = f.Retirada,
                ValorDaSaida = f.ValorDeSaida,
                ValorEntrada = f.ValorDeEntrada,
                Saldo = f.Saldo,
                Status = StatusCaixa(f.Saldo),
            }).OrderByDescending(c => DateTime.Parse(c.DiaFechamento)).ToList();
        }

        public IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(int id)
        {
            var movimentos = this._caixaRepository.GetAll().Where(c => c.Id.Equals(id)).FirstOrDefault().MovimentosDoCaixa;

            return movimentos.Where(m => m.TipoMovimentoCaixa == (int)ETipoMovimentoCaixa.Entrada).Select(m => new MovimentoCaixaAppModel
            {
                Descricao = m.Descricao,
                Valor = m.Valor
            });
        }

        public IEnumerable<MovimentoCaixaAppModel> ObterSaidasDoCaixa(int id)
        {
            var movimentos = this._caixaRepository.GetAll().Where(c => c.Id.Equals(id)).FirstOrDefault().MovimentosDoCaixa;

            return movimentos.Where(m => m.TipoMovimentoCaixa == (int)ETipoMovimentoCaixa.Saida).Select(m => new MovimentoCaixaAppModel
            {
                Descricao = m.Descricao,
                Valor = m.Valor
            });
        }

        public void CadastrarFechamentoDiario(FechamentoDiarioAppModel appServiceModel)
        {

            var caixaCadastrado = _caixaRepository.Get(c => c.DiaFechamento.Equals(appServiceModel.DiaFechamento)).FirstOrDefault();

            if (caixaCadastrado != null)
            {
                _caixaRepository.Excluir(caixaCadastrado);
            }

            var caixa = new Caixa
            {
                CaixaInicioDoDia = appServiceModel.CaixaInicioDoDia,
                DiaFechamento = appServiceModel.DiaFechamento,
                Funcionario = appServiceModel.Funcionario,
                Retirada = appServiceModel.ValorDaRetirada,
                ValorDeEntrada = appServiceModel.ValorEntrada,
                ValorDeSaida = appServiceModel.ValorDaSaida,
                CaixaFinalDoDia = appServiceModel.CaixaFinalDoDia,
                Saldo = appServiceModel.Saldo
            };

            caixa.MovimentosDoCaixa = GerarMovimentosDoCaixa(appServiceModel.Saidas, appServiceModel.Entradas, caixa);

            this._caixaRepository.Adicionar(caixa);

            this._caixaRepository.SalvarTodos();
        }

        private ICollection<MovimentoDoCaixa> GerarMovimentosDoCaixa(IEnumerable<MovimentoCaixaAppModel> saidas,
            IEnumerable<MovimentoCaixaAppModel> entradas, Caixa caixa)
        {
            var movimentos = new List<MovimentoDoCaixa>();


            foreach (var itemSaida in saidas)
            {
                movimentos.Add(new MovimentoDoCaixa
                {
                    Descricao = itemSaida.Descricao,
                    Valor = itemSaida.Valor,
                    Caixa = caixa,
                    TipoMovimentoCaixa = (int)ETipoMovimentoCaixa.Saida
                });
            }

            foreach (var itemEntrada in entradas)
            {
                movimentos.Add(new MovimentoDoCaixa
                {
                    Descricao = itemEntrada.Descricao,
                    Valor = itemEntrada.Valor,
                    Caixa = caixa,
                    TipoMovimentoCaixa = (int)ETipoMovimentoCaixa.Entrada
                });
            }

            return movimentos;
        }

        public int CountObterFechamentos()
        {
            return this._caixaRepository.CountObterFechamentos();
        }

        public int CountObterFechamentosDoDia(string filtroDia)
        {
            return this._caixaRepository.CountObterFechamentosDoDia(filtroDia);
        }

        public IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(string diaFechamento)
        {
            var movimentos = this._caixaRepository.GetAll().FirstOrDefault(c => c.DiaFechamento.Equals(diaFechamento)).MovimentosDoCaixa;

            return movimentos.Where(m => m.TipoMovimentoCaixa == (int)ETipoMovimentoCaixa.Entrada).Select(m => new MovimentoCaixaAppModel
            {
                Descricao = m.Descricao,
                Valor = m.Valor
            });
        }

        public IEnumerable<MovimentoCaixaAppModel> ObterSaidasDoCaixa(string diaFechamento)
        {
            var movimentos = this._caixaRepository.GetAll().FirstOrDefault(c => c.DiaFechamento.Equals(diaFechamento)).MovimentosDoCaixa;

            return movimentos.Where(m => m.TipoMovimentoCaixa == (int)ETipoMovimentoCaixa.Saida).Select(m => new MovimentoCaixaAppModel
            {
                Descricao = m.Descricao,
                Valor = m.Valor
            });
        }
    }
}
