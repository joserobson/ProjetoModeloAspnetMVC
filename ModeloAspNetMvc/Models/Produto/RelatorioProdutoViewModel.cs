using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Produto
{
    public class RelatorioProdutoViewModel
    {
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Estoque")]
        public int Estoque { get; set; }

        [Display(Name = "Valor")]
        public string Preço { get; set; }
    }
}