using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModeloAspNetMvc.Models.Caixa
{
    public class TelaFechamentoDiarioModel
    {
        public DateTime FiltroDia { get; set; }

        public IEnumerable<FechamentoDiarioModel> Fechamentos { get; set; }

        public TelaFechamentoDiarioModel()
        {
            this.Fechamentos = new List<FechamentoDiarioModel>();
        }
    }
}