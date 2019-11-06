
using System.ComponentModel.DataAnnotations;


namespace ModeloAspNetMvc.Models.Login
{    

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuário")]        
        public string Usuario { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}