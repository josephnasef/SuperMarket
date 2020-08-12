namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Operations", "AppUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "AppUserId", c => c.Int(nullable: false));
        }
    }
}
