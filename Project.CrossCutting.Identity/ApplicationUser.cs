using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.CrossCutting.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Ativo = true;
            FilialId = 1;
        }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório"), StringLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Filial é obrigatória.")]
        public int FilialId { get; set; }        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
