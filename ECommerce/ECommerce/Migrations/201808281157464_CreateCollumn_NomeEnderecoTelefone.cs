namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCollumn_NomeEnderecoTelefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVenda", "NomeCliente", c => c.String());
            AddColumn("dbo.ItemVenda", "EnderecoCliente", c => c.String());
            AddColumn("dbo.ItemVenda", "TelefoneCliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemVenda", "TelefoneCliente");
            DropColumn("dbo.ItemVenda", "EnderecoCliente");
            DropColumn("dbo.ItemVenda", "NomeCliente");
        }
    }
}
