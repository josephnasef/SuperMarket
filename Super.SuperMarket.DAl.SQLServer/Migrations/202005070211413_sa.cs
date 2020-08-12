namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                        BirthDay = c.DateTime(),
                        DateOfCreation = c.DateTime(nullable: false),
                        PhotoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfMake = c.DateTime(nullable: false),
                        FullPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfExpire = c.DateTime(nullable: false),
                        OperationTypeId = c.Int(nullable: false),
                        paymentMethodId = c.Int(nullable: false),
                        AppUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.OperationTypes", t => t.OperationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.paymentMethodId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.OperationTypeId)
                .Index(t => t.paymentMethodId);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfCreation = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AppUserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OperationTypeId = c.Int(nullable: false),
                        Bill_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Bills", t => t.Bill_Id)
                .ForeignKey("dbo.OperationTypes", t => t.OperationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.Bill_Id)
                .Index(t => t.OperationTypeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OperationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarcodeNumber = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MadeInCountry = c.String(),
                        ProductionDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        DateOfInsert = c.DateTime(nullable: false),
                        HasGuarantee = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SupplierId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                        LasetUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        Rate = c.Int(nullable: false),
                        AppUserId = c.Int(nullable: false),
                        DateOfCreation = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BanckName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        BanckAccountNumber = c.Int(nullable: false),
                        Password = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductBills",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Bill_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Bill_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bills", t => t.Bill_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Bill_Id);
            
            CreateTable(
                "dbo.SupplierCategories",
                c => new
                    {
                        Supplier_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supplier_Id, t.Category_Id })
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Supplier_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.PaymentMethodSuppliers",
                c => new
                    {
                        PaymentMethod_Id = c.Int(nullable: false),
                        Supplier_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaymentMethod_Id, t.Supplier_Id })
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id, cascadeDelete: true)
                .Index(t => t.PaymentMethod_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.SupplierSuppliers",
                c => new
                    {
                        Supplier_Id = c.Int(nullable: false),
                        Supplier_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supplier_Id, t.Supplier_Id1 })
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id1)
                .Index(t => t.Supplier_Id)
                .Index(t => t.Supplier_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUsers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Operations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SupplierSuppliers", "Supplier_Id1", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierSuppliers", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PaymentMethodSuppliers", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.PaymentMethodSuppliers", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.Bills", "paymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.SupplierCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.SupplierCategories", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.BankAccounts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductBills", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.ProductBills", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Operations", "OperationTypeId", "dbo.OperationTypes");
            DropForeignKey("dbo.Bills", "OperationTypeId", "dbo.OperationTypes");
            DropForeignKey("dbo.Operations", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.Operations", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Bills", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.AppUsers", new[] { "RoleId" });
            DropIndex("dbo.Operations", new[] { "ProductId" });
            DropIndex("dbo.SupplierSuppliers", new[] { "Supplier_Id1" });
            DropIndex("dbo.SupplierSuppliers", new[] { "Supplier_Id" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.PaymentMethodSuppliers", new[] { "Supplier_Id" });
            DropIndex("dbo.PaymentMethodSuppliers", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.Bills", new[] { "paymentMethodId" });
            DropIndex("dbo.SupplierCategories", new[] { "Category_Id" });
            DropIndex("dbo.SupplierCategories", new[] { "Supplier_Id" });
            DropIndex("dbo.BankAccounts", new[] { "SupplierId" });
            DropIndex("dbo.Suppliers", new[] { "AppUserId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ProductBills", new[] { "Bill_Id" });
            DropIndex("dbo.ProductBills", new[] { "Product_Id" });
            DropIndex("dbo.Operations", new[] { "OperationTypeId" });
            DropIndex("dbo.Bills", new[] { "OperationTypeId" });
            DropIndex("dbo.Operations", new[] { "Bill_Id" });
            DropIndex("dbo.Operations", new[] { "AppUserId" });
            DropIndex("dbo.Bills", new[] { "AppUserId" });
            DropTable("dbo.SupplierSuppliers");
            DropTable("dbo.PaymentMethodSuppliers");
            DropTable("dbo.SupplierCategories");
            DropTable("dbo.ProductBills");
            DropTable("dbo.Roles");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.OperationTypes");
            DropTable("dbo.Operations");
            DropTable("dbo.Bills");
            DropTable("dbo.AppUsers");
        }
    }
}
