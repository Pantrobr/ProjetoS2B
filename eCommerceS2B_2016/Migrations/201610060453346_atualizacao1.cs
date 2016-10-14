namespace eCommerceS2B_2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacao1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Usuarios");
            RenameColumn(table: "dbo.Compras", name: "User_UserID", newName: "Usuarios_UserID");
            RenameColumn(table: "dbo.Vendas", name: "User_UserID", newName: "Usuarios_UserID");
            RenameIndex(table: "dbo.Compras", name: "IX_User_UserID", newName: "IX_Usuarios_UserID");
            RenameIndex(table: "dbo.Vendas", name: "IX_User_UserID", newName: "IX_Usuarios_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vendas", name: "IX_Usuarios_UserID", newName: "IX_User_UserID");
            RenameIndex(table: "dbo.Compras", name: "IX_Usuarios_UserID", newName: "IX_User_UserID");
            RenameColumn(table: "dbo.Vendas", name: "Usuarios_UserID", newName: "User_UserID");
            RenameColumn(table: "dbo.Compras", name: "Usuarios_UserID", newName: "User_UserID");
            RenameTable(name: "dbo.Usuarios", newName: "Users");
        }
    }
}
