namespace ProjetoS2B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class att1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Senha", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Senha", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
