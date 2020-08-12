namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductBills", newName: "BillProducts");
            RenameTable(name: "dbo.SupplierPaymentMethods", newName: "PaymentMethodSuppliers");
            DropForeignKey("dbo.Operations", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Operations", new[] { "AppUserId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Operations", "AppUserId");
            AddForeignKey("dbo.Operations", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.PaymentMethodSuppliers", newName: "SupplierPaymentMethods");
            RenameTable(name: "dbo.BillProducts", newName: "ProductBills");
        }
    }
}
