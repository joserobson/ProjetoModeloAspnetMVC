using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Layer.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {            
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool Excluido { get; set; }

         
    }
}
