namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "ItemNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operations", "ItemNumber");
        }
    }
}
