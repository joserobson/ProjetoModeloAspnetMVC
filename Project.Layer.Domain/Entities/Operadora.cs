using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class Operadora : BaseEntity
    {
        public Operadora()
        {
            this.Telefones = new HashSet<Telefone>();
        }
        [Required(ErrorMessage = "O campo Nome da Operadora é obrigatório."), StringLength(250), Display(Name = "Nome da Operadora")]
        public string NomeOperadora { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
