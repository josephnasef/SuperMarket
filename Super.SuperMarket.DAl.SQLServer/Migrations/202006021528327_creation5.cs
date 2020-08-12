namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SupplierCategories", newName: "CategorySuppliers");
            RenameTable(name: "dbo.PaymentMethodSuppliers", newName: "SupplierPaymentMethods");
            DropForeignKey("dbo.Bills", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Bills", new[] { "AppUserId" });
            DropColumn("dbo.Bills", "AppUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bills", "AppUserId");
            AddForeignKey("dbo.Bills", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.SupplierPaymentMethods", newName: "PaymentMethodSuppliers");
            RenameTable(name: "dbo.CategorySuppliers", newName: "SupplierCategories");
        }
    }
}
