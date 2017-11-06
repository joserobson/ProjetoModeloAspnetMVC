using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco() { }
        [Display(Name = "Principal")]
        public bool Principal { get; set; }
        public Nullable<int> TipoEnderecoId { get; set; }
        [Required(ErrorMessage = "O campo CEP é obrigatório."), StringLength(15), Display(Name = "CEP")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo Logradouro é obrigatório."), StringLength(250), Display(Name = "Logradouro")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo Número é obrigatório."), StringLength(10), Display(Name = "Número")]
        public string Numero { get; set; }
        [StringLength(250), Display(Name = "Complemento")]
        public string Complemento { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatório."), StringLength(250), Display(Name = "Bairro")]
        public string Bairro { get; set; }
        public Nullable<int> CidadeId { get; set; }
        [StringLength(250), Display(Name = "Referência")]
        public string Referencia { get; set; }
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }
        public Nullable<int> EstadoId { get; set; }
        public Nullable<int> TransportadoraId { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> FornecedorId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }        
        public virtual Cliente Cliente { get; set; }        
    }
}
