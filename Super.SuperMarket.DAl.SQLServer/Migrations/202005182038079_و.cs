namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class و : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ShippingDetails", "CreatedDate");
            DropColumn("dbo.ShippingDetails", "CreatedBy");
            DropColumn("dbo.ShippingDetails", "UpdatedDate");
            DropColumn("dbo.ShippingDetails", "UpdatedBy");
            DropColumn("dbo.ShippingDetails", "IsArchived");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShippingDetails", "IsArchived", c => c.Boolean(nullable: false));
            AddColumn("dbo.ShippingDetails", "UpdatedBy", c => c.String());
            AddColumn("dbo.ShippingDetails", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.ShippingDetails", "CreatedBy", c => c.String());
            AddColumn("dbo.ShippingDetails", "CreatedDate", c => c.DateTime());
        }
    }
}
