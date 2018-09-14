namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColumnLocalidadeToCidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Cidade", c => c.String());
            DropColumn("dbo.Usuarios", "Localidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Localidade", c => c.String());
            DropColumn("dbo.Usuarios", "Cidade");
        }
    }
}
