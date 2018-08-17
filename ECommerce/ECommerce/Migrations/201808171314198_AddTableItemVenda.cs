namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableItemVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVenda",
                c => new
                    {
                        ItemVendaID = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        ProdutoVenda_ProdutoID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaID)
                .ForeignKey("dbo.Produtos", t => t.ProdutoVenda_ProdutoID)
                .Index(t => t.ProdutoVenda_ProdutoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "ProdutoVenda_ProdutoID", "dbo.Produtos");
            DropIndex("dbo.ItemVenda", new[] { "ProdutoVenda_ProdutoID" });
            DropTable("dbo.ItemVenda");
        }
    }
}
