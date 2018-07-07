using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModeloAspNetMvc.Models.Caixa
{
    public class TelaFechamentoDiarioModel
    {
        
        [Display(Name ="Dia do Fechamento")]
        public string FiltroDia { get; set; }

        public IEnumerable<FechamentoDiarioModel> Fechamentos { get; set; }

        public TelaFechamentoDiarioModel()
        {
            this.Fechamentos = new List<FechamentoDiarioModel>();
        }
    }
}