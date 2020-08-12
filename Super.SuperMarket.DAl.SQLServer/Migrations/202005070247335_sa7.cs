namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Bills", "CreatedBy", c => c.String());
            AddColumn("dbo.Bills", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Bills", "UpdatedBy", c => c.String());
            AddColumn("dbo.Bills", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Operations", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Operations", "CreatedBy", c => c.String());
            AddColumn("dbo.Operations", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Operations", "UpdatedBy", c => c.String());
            AddColumn("dbo.Operations", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.OperationTypes", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.OperationTypes", "CreatedBy", c => c.String());
            AddColumn("dbo.OperationTypes", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.OperationTypes", "UpdatedBy", c => c.String());
            AddColumn("dbo.OperationTypes", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Products", "CreatedBy", c => c.String());
            AddColumn("dbo.Products", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Products", "UpdatedBy", c => c.String());
            AddColumn("dbo.Products", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.BankAccounts", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.BankAccounts", "CreatedBy", c => c.String());
            AddColumn("dbo.BankAccounts", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.BankAccounts", "UpdatedBy", c => c.String());
            AddColumn("dbo.BankAccounts", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaymentMethods", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.PaymentMethods", "CreatedBy", c => c.String());
            AddColumn("dbo.PaymentMethods", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.PaymentMethods", "UpdatedBy", c => c.String());
            AddColumn("dbo.PaymentMethods", "IsArchived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentMethods", "IsArchived");
            DropColumn("dbo.PaymentMethods", "UpdatedBy");
            DropColumn("dbo.PaymentMethods", "UpdatedDate");
            DropColumn("dbo.PaymentMethods", "CreatedBy");
            DropColumn("dbo.PaymentMethods", "CreatedDate");
            DropColumn("dbo.BankAccounts", "IsArchived");
            DropColumn("dbo.BankAccounts", "UpdatedBy");
            DropColumn("dbo.BankAccounts", "UpdatedDate");
            DropColumn("dbo.BankAccounts", "CreatedBy");
            DropColumn("dbo.BankAccounts", "CreatedDate");
            DropColumn("dbo.Products", "IsArchived");
            DropColumn("dbo.Products", "UpdatedBy");
            DropColumn("dbo.Products", "UpdatedDate");
            DropColumn("dbo.Products", "CreatedBy");
            DropColumn("dbo.Products", "CreatedDate");
            DropColumn("dbo.OperationTypes", "IsArchived");
            DropColumn("dbo.OperationTypes", "UpdatedBy");
            DropColumn("dbo.OperationTypes", "UpdatedDate");
            DropColumn("dbo.OperationTypes", "CreatedBy");
            DropColumn("dbo.OperationTypes", "CreatedDate");
            DropColumn("dbo.Operations", "IsArchived");
            DropColumn("dbo.Operations", "UpdatedBy");
            DropColumn("dbo.Operations", "UpdatedDate");
            DropColumn("dbo.Operations", "CreatedBy");
            DropColumn("dbo.Operations", "CreatedDate");
            DropColumn("dbo.Bills", "IsArchived");
            DropColumn("dbo.Bills", "UpdatedBy");
            DropColumn("dbo.Bills", "UpdatedDate");
            DropColumn("dbo.Bills", "CreatedBy");
            DropColumn("dbo.Bills", "CreatedDate");
        }
    }
}
