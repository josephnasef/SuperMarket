namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BillProducts", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.BillProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.BillProducts", new[] { "Bill_Id" });
            DropIndex("dbo.BillProducts", new[] { "Product_Id" });
            DropTable("dbo.BillProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BillProducts",
                c => new
                    {
                        Bill_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bill_Id, t.Product_Id });
            
            CreateIndex("dbo.BillProducts", "Product_Id");
            CreateIndex("dbo.BillProducts", "Bill_Id");
            AddForeignKey("dbo.BillProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BillProducts", "Bill_Id", "dbo.Bills", "Id", cascadeDelete: true);
        }
    }
}
