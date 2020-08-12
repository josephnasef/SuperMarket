namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "DateOfInsert");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DateOfInsert", c => c.DateTime(nullable: false));
        }
    }
}
