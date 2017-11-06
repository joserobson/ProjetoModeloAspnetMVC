using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class Telefone : BaseEntity
    {
        public Telefone() { }
        [Required(ErrorMessage = "O campo Número é obrigatório."), StringLength(15), Display(Name = "Número")]
        public string Numero { get; set; }
        public Nullable<int> OperadoraId { get; set; }
        public Nullable<int> TransportadoraId { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> FornecedorId { get; set; }

        public virtual Operadora Operadora { get; set; }        
        public virtual Cliente Cliente { get; set; }        
    }
}
