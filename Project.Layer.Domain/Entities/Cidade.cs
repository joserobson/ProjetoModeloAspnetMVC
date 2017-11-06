using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class Cidade : BaseEntity
    {
        public Cidade()
        {
            this.Enderecos = new HashSet<Endereco>();
        }
        [Required(ErrorMessage = "O campo Nome da Cidade é obrigatório."), StringLength(250), Display(Name = "Nome da Cidade")]
        public string NomeCidade { get; set; }
        [Required(ErrorMessage = "O campo Estado é obrigatório."), Display(Name = "Estado")]
        public Estado Estado { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
