using Microsoft.AspNet.Identity.EntityFramework;
using Project.CrossCutting.Identity;
using Project.Layer.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project.Layer.Data.Contexto
{
    public class ProjectContext : IdentityDbContext<ApplicationUser>
    {

        public ProjectContext() : base("DefaultConnection")
        {
            Database.SetInitializer<ProjectContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Caixa>().ToTable("tb_caixa");
            modelBuilder.Entity<Caixa>().Property(x => x.Id).HasColumnName("Id");
            modelBuilder.Entity<Caixa>().Property(x => x.CaixaInicioDoDia).HasColumnName("caixa_inicio_dia");
            modelBuilder.Entity<Caixa>().Property(x => x.DiaFechamento).HasColumnName("dia_fechamento");            
            modelBuilder.Entity<Caixa>().Property(x => x.ValorDeEntrada).HasColumnName("valor_entrada");
            modelBuilder.Entity<Caixa>().Property(x => x.ValorDeSaida).HasColumnName("valor_saida");
            modelBuilder.Entity<Caixa>().Property(x => x.Retirada).HasColumnName("retirada");
            modelBuilder.Entity<Caixa>().Property(x => x.Funcionario).HasColumnName("funcionario");
            modelBuilder.Entity<Caixa>().Property(x => x.CaixaFinalDoDia).HasColumnName("caixa_final_dia");
            modelBuilder.Entity<Caixa>().Property(x => x.Saldo).HasColumnName("saldo");


            modelBuilder.Entity<MovimentoDoCaixa>().ToTable("tb_movimento_caixa");
            modelBuilder.Entity<MovimentoDoCaixa>().Property(x => x.Id).HasColumnName("id");
            //modelBuilder.Entity<MovimentoDoCaixa>().Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MovimentoDoCaixa>().Property(x => x.Descricao).HasColumnName("descricao_movimento");
            modelBuilder.Entity<MovimentoDoCaixa>().Property(x => x.Valor).HasColumnName("valor_movimento");
            modelBuilder.Entity<MovimentoDoCaixa>().Property(x => x.TipoMovimentoCaixa).HasColumnName("tipo_movimento_caixa");
            modelBuilder.Entity<MovimentoDoCaixa>().Property(x => x.IdDoCaixa).HasColumnName("id_caixa");

            modelBuilder.Entity<MovimentoDoCaixa>()
                .HasRequired<Caixa>(s => s.Caixa)
                .WithMany(g => g.MovimentosDoCaixa)
                .HasForeignKey<int>(s => s.IdDoCaixa);

            base.OnModelCreating(modelBuilder);
        }

        #region DbSet<Entity>

        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<MovimentoDoCaixa> MovimentoDoCaixa { get; set; }

        //public DbSet<Pais> Pais { get; set; }
        //public DbSet<Estado> Estado { get; set; }
        //public DbSet<Cidade> Cidade { get; set; }
        //public DbSet<Cliente> Cliente { get; set; }

        //public DbSet<TipoEndereco> TipoEndereco { get; set; }
        //public DbSet<Endereco> Endereco { get; set; }
        //public DbSet<Operadora> Operadora { get; set; }
        //public DbSet<Telefone> Telefone { get; set; }

        #endregion
    }
}
