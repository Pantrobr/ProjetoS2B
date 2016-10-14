namespace eCommerceS2B_2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraID = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(nullable: false),
                        IdVendedor = c.Int(nullable: false),
                        IdComprador = c.Int(nullable: false),
                        DataDaCompra = c.DateTime(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CompraID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Imagem = c.Binary(),
                        IdVendedor = c.Int(nullable: false),
                        GeneroProduto = c.Int(nullable: false),
                        Description = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Imagem = c.Binary(),
                        NroVendas = c.Int(nullable: false),
                        NroCompras = c.Int(nullable: false),
                        NroLikes = c.Int(nullable: false),
                        NroDislikes = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendasID = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(nullable: false),
                        IdVendedor = c.Int(nullable: false),
                        IdComprador = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 25),
                        Status = c.Boolean(nullable: false),
                        Local = c.String(maxLength: 200),
                        DataDaVenda = c.DateTime(nullable: false),
                        DataDaPostagem = c.DateTime(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.VendasID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Compras", "User_UserID", "dbo.Users");
            DropIndex("dbo.Vendas", new[] { "User_UserID" });
            DropIndex("dbo.Compras", new[] { "User_UserID" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Users");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Compras");
        }
    }
}
