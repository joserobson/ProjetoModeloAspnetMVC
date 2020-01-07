using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Venda
{
    public class ResumoVendaPorFuncionarioModel
    {
        [Display(Name = "Qtd de Vendas")]
        public int QtdVendas { get; set; }

        [Display(Name = "Total Em vendas")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalEmVendas { get; set; }

        [Display(Name = "Funcionário")]
        public string Funcionario { get; set; }
    }
}