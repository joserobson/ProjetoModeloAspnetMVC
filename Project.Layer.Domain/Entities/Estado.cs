using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class Estado : BaseEntity
    {
        public Estado()
        {
            this.Cidades = new HashSet<Cidade>();
        }
        [Required(ErrorMessage = "O campo Estado é obrigatório."), StringLength(250), Display(Name = "Estado")]
        public string NomeEstado { get; set; }
        [StringLength(250), Display(Name = "Sigla do Estado")]
        public string SiglaEstado { get; set; }
        [Required(ErrorMessage = "O campo País é obrigatório."), Display(Name = "País")]
        public Pais Pais { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
