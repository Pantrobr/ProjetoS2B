namespace eCommerceS2B_2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizaçao2 : DbMigration
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
            
            AddColumn("dbo.Usuarios", "Avatar_ArquivoId", c => c.Int());
            CreateIndex("dbo.Usuarios", "Avatar_ArquivoId");
            AddForeignKey("dbo.Usuarios", "Avatar_ArquivoId", "dbo.Arquivoes", "ArquivoId");
            DropColumn("dbo.Produtoes", "Imagem");
            DropColumn("dbo.Usuarios", "Imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Imagem", c => c.Binary());
            AddColumn("dbo.Produtoes", "Imagem", c => c.Binary());
            DropForeignKey("dbo.Usuarios", "Avatar_ArquivoId", "dbo.Arquivoes");
            DropForeignKey("dbo.Arquivoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Usuarios", new[] { "Avatar_ArquivoId" });
            DropIndex("dbo.Arquivoes", new[] { "ProdutoId" });
            DropColumn("dbo.Usuarios", "Avatar_ArquivoId");
            DropTable("dbo.Arquivoes");
        }
    }
}
