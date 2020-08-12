namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class show : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ShowInMenu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ShowInMenu");
        }
    }
}
