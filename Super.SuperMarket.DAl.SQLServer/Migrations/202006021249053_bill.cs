namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bill : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bills", "DateOfMake");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "DateOfMake", c => c.DateTime(nullable: false));
        }
    }
}
