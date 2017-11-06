using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class Pais : BaseEntity
    {
        public Pais()
        {
            this.Estados = new HashSet<Estado>();
        }
        [Required(ErrorMessage = "O campo Nome do País é obrigatório."), StringLength(250), Display(Name = "Nome do País")]
        public string NomePais { get; set; }
        [Required(ErrorMessage = "O campo Sigla do País é obrigatório."), StringLength(250), Display(Name = "Sigla do País")]
        public string SiglasPais { get; set; }
        public virtual ICollection<Estado> Estados { get; set; }
    }
}
