using System;

namespace Project.Layer.App.AppModels.Caixa
{
    public class CaixaEntradaAppModel
    {
        public DateTime DataEntrada { get; set; }
        public string Descricao { get; set; }
        public string IdVenda { get; set; }
        public string Id { get; set; }
        public decimal Valor { get; set; }
    }
}
