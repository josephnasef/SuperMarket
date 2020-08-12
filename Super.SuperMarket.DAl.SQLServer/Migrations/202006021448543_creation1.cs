namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Operations", "DateOfCreation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "DateOfCreation", c => c.DateTime(nullable: false));
        }
    }
}
