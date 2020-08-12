namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShippingDetails", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ShippingDetails", "CreatedBy", c => c.String());
            AddColumn("dbo.ShippingDetails", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ShippingDetails", "UpdatedBy", c => c.String());
            AddColumn("dbo.ShippingDetails", "IsArchived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShippingDetails", "IsArchived");
            DropColumn("dbo.ShippingDetails", "UpdatedBy");
            DropColumn("dbo.ShippingDetails", "UpdatedDate");
            DropColumn("dbo.ShippingDetails", "CreatedBy");
            DropColumn("dbo.ShippingDetails", "CreatedDate");
        }
    }
}
