﻿using Project.Layer.App.AppModels.Caixa;
using System.Collections.Generic;

namespace Project.Layer.App.AppServices
{
    public interface ICaixaAppService
    {
        IEnumerable<FechamentoDiarioAppModel> ObterFechamentos(int currentPage, int maxRows);
        IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(int id);
        IEnumerable<MovimentoCaixaAppModel> ObterSaidasDoCaixa(int id);

        IEnumerable<MovimentoCaixaAppModel> ObterEntradasDoCaixa(string diaFechamento);
        IEnumerable<MovimentoCaixaAppModel> ObterSaidasDoCaixa(string diaFechamento);

        void CadastrarFechamentoDiario(FechamentoDiarioAppModel appServiceModel);
        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoDia(string diaFechamento, int currentPage, int maxRows);
        int CountObterFechamentos();
        int CountObterFechamentosDoDia(string filtroDia);
        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosComDetalhes();

        IEnumerable<FechamentoDiarioAppModel> ObterFechamentosDoMes(string mes);

    }
}
