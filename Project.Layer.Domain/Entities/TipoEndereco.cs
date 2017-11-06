using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class TipoEndereco : BaseEntity
    {
        public TipoEndereco()
        {
            this.Enderecos = new HashSet<Endereco>();
        }
        [Required(ErrorMessage = "O campo Descrição é obrigatório."), StringLength(250), Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
