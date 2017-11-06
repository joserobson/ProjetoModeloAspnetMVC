namespace Project.Layer.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _20170611scritpbd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCidade = c.String(nullable: false, maxLength: 250),
                        Excluido = c.Boolean(nullable: false),
                        Estado_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.Estado_Id, cascadeDelete: true)
                .Index(t => t.Estado_Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Principal = c.Boolean(nullable: false),
                        TipoEnderecoId = c.Int(),
                        Cep = c.String(nullable: false, maxLength: 15),
                        Logradouro = c.String(nullable: false, maxLength: 250),
                        Numero = c.String(nullable: false, maxLength: 10),
                        Complemento = c.String(maxLength: 250),
                        Bairro = c.String(nullable: false, maxLength: 250),
                        CidadeId = c.Int(),
                        Referencia = c.String(maxLength: 250),
                        Observacoes = c.String(),
                        EstadoId = c.Int(),
                        TransportadoraId = c.Int(),
                        ClienteId = c.Int(),
                        FornecedorId = c.Int(),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .ForeignKey("dbo.TipoEndereco", t => t.TipoEnderecoId)
                .Index(t => t.TipoEnderecoId)
                .Index(t => t.CidadeId)
                .Index(t => t.EstadoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bloqueado = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Observacoes = c.String(),
                        Inativo = c.Boolean(nullable: false),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(nullable: false, maxLength: 15),
                        OperadoraId = c.Int(),
                        TransportadoraId = c.Int(),
                        ClienteId = c.Int(),
                        FornecedorId = c.Int(),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Operadora", t => t.OperadoraId)
                .Index(t => t.OperadoraId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Operadora",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeOperadora = c.String(nullable: false, maxLength: 250),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeEstado = c.String(nullable: false, maxLength: 250),
                        SiglaEstado = c.String(maxLength: 250),
                        Excluido = c.Boolean(nullable: false),
                        Pais_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pais", t => t.Pais_Id, cascadeDelete: true)
                .Index(t => t.Pais_Id);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomePais = c.String(nullable: false, maxLength: 250),
                        SiglasPais = c.String(nullable: false, maxLength: 250),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoEndereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 250),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ativo = c.Boolean(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 200),
                        FilialId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cidade", "Estado_Id", "dbo.Estado");
            DropForeignKey("dbo.Endereco", "TipoEnderecoId", "dbo.TipoEndereco");
            DropForeignKey("dbo.Endereco", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Estado", "Pais_Id", "dbo.Pais");
            DropForeignKey("dbo.Telefone", "OperadoraId", "dbo.Operadora");
            DropForeignKey("dbo.Telefone", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "CidadeId", "dbo.Cidade");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Estado", new[] { "Pais_Id" });
            DropIndex("dbo.Telefone", new[] { "ClienteId" });
            DropIndex("dbo.Telefone", new[] { "OperadoraId" });
            DropIndex("dbo.Endereco", new[] { "ClienteId" });
            DropIndex("dbo.Endereco", new[] { "EstadoId" });
            DropIndex("dbo.Endereco", new[] { "CidadeId" });
            DropIndex("dbo.Endereco", new[] { "TipoEnderecoId" });
            DropIndex("dbo.Cidade", new[] { "Estado_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TipoEndereco");
            DropTable("dbo.Pais");
            DropTable("dbo.Estado");
            DropTable("dbo.Operadora");
            DropTable("dbo.Telefone");
            DropTable("dbo.Cliente");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cidade");
        }
    }
}
