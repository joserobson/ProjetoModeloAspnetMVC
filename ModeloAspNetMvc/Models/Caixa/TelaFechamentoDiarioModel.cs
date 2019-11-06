using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Caixa
{
    public class TelaFechamentoDiarioModel
    {
        
        [Display(Name ="Dia do Fechamento")]
        public string FiltroDia { get; set; }

        [Display(Name = "Mês")]
        public string Mes { get; set; }


        [Display(Name = "Ano")]
        public string Ano { get; set; }

        public IEnumerable<FechamentoDiarioModel> Fechamentos { get; set; }

        public int PageSize { get; set; }

        public int? PageNumber { get; set; }

        public int TotalItemCount { get; set; }

        public TelaFechamentoDiarioModel()
        {
            this.Fechamentos = new List<FechamentoDiarioModel>();
        }
    }
}