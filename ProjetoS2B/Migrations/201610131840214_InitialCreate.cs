namespace ProjetoS2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivoes",
                c => new
                    {
                        ArquivoId = c.Int(nullable: false, identity: true),
                        NomeArquivo = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        TipoArquivo = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArquivoId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        IdVendedor = c.Int(nullable: false),
                        GeneroProduto = c.Int(nullable: false),
                        Description = c.String(),
                        Disponivel = c.Boolean(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Usuario_UserID = c.Int(),
                        Usuario_UserID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UserID)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UserID1)
                .Index(t => t.Usuario_UserID)
                .Index(t => t.Usuario_UserID1);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        NroVendas = c.Int(nullable: false),
                        NroCompras = c.Int(nullable: false),
                        NroLikes = c.Int(nullable: false),
                        NroDislikes = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 20),
                        SenhaRocks = c.String(),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Login = c.String(nullable: false),
                        Avatar_ArquivoId = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Arquivoes", t => t.Avatar_ArquivoId)
                .Index(t => t.Avatar_ArquivoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Usuario_UserID1", "dbo.Usuarios");
            DropForeignKey("dbo.Produtoes", "Usuario_UserID", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Avatar_ArquivoId", "dbo.Arquivoes");
            DropForeignKey("dbo.Arquivoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Usuarios", new[] { "Avatar_ArquivoId" });
            DropIndex("dbo.Produtoes", new[] { "Usuario_UserID1" });
            DropIndex("dbo.Produtoes", new[] { "Usuario_UserID" });
            DropIndex("dbo.Arquivoes", new[] { "ProdutoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Arquivoes");
        }
    }
}
