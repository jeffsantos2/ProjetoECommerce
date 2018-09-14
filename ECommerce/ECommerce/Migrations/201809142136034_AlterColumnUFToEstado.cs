namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnUFToEstado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Estado", c => c.String());
            DropColumn("dbo.Usuarios", "UF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "UF", c => c.String());
            DropColumn("dbo.Usuarios", "Estado");
        }
    }
}
