using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Layer.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
            this.Enderecos = new HashSet<Endereco>();
            this.Telefones = new HashSet<Telefone>();
        }
        [Display(Name = "Bloqueado")]
        public bool Bloqueado { get; set; }
        [Display(Name = "DataCadastro")]
        public DateTime DataCadastro { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório."), StringLength(250), Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo E-mail é obrigatório."), StringLength(250), Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Observacoes")]
        public string Observacoes { get; set; }
        public bool Inativo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
