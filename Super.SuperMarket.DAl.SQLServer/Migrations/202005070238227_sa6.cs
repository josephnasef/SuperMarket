namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Categories", "CreatedBy", c => c.String());
            AddColumn("dbo.Categories", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Categories", "UpdatedBy", c => c.String());
            AddColumn("dbo.Categories", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Suppliers", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Suppliers", "CreatedBy", c => c.String());
            AddColumn("dbo.Suppliers", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Suppliers", "UpdatedBy", c => c.String());
            AddColumn("dbo.Suppliers", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Roles", "CreatedBy", c => c.String());
            AddColumn("dbo.Roles", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Roles", "UpdatedBy", c => c.String());
            AddColumn("dbo.Roles", "IsArchived", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "DateOfCreation");
            DropColumn("dbo.Categories", "LasetUpdate");
            DropColumn("dbo.Suppliers", "DateOfCreation");
            DropColumn("dbo.Roles", "DateOfCreation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "DateOfCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Suppliers", "DateOfCreation", c => c.DateTime());
            AddColumn("dbo.Categories", "LasetUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "DateOfCreation", c => c.DateTime(nullable: false));
            DropColumn("dbo.Roles", "IsArchived");
            DropColumn("dbo.Roles", "UpdatedBy");
            DropColumn("dbo.Roles", "UpdatedDate");
            DropColumn("dbo.Roles", "CreatedBy");
            DropColumn("dbo.Roles", "CreatedDate");
            DropColumn("dbo.Suppliers", "IsArchived");
            DropColumn("dbo.Suppliers", "UpdatedBy");
            DropColumn("dbo.Suppliers", "UpdatedDate");
            DropColumn("dbo.Suppliers", "CreatedBy");
            DropColumn("dbo.Suppliers", "CreatedDate");
            DropColumn("dbo.Categories", "IsArchived");
            DropColumn("dbo.Categories", "UpdatedBy");
            DropColumn("dbo.Categories", "UpdatedDate");
            DropColumn("dbo.Categories", "CreatedBy");
            DropColumn("dbo.Categories", "CreatedDate");
        }
    }
}
