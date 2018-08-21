namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnCarrinhoID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVenda", "CarrinhoID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemVenda", "CarrinhoID");
        }
    }
}
