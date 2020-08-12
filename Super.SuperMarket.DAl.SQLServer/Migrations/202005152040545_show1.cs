namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class show1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "HiddInMenu", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "ShowInMenu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ShowInMenu", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "HiddInMenu");
        }
    }
}
