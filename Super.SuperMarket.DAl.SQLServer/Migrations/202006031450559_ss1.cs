namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Operations", "ItemNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "ItemNumber", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
