namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "DateOfCreation", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "DateOfCreation", c => c.DateTime(nullable: false));
        }
    }
}
