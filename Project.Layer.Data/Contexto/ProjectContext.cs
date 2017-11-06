using Microsoft.AspNet.Identity.EntityFramework;
using Project.CrossCutting.Identity;
using Project.Layer.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project.Layer.Data.Contexto
{
    public class ProjectContext: IdentityDbContext<ApplicationUser>
    {

        public ProjectContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        #region DbSet<Entity>

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<TipoEndereco> TipoEndereco { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        #endregion
    }
}
