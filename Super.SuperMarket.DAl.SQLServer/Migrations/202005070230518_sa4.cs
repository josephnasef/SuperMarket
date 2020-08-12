namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppUsers", "CreatedBy", c => c.String());
            AddColumn("dbo.AppUsers", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppUsers", "UpdatedBy", c => c.String());
            AddColumn("dbo.AppUsers", "IsArchived", c => c.Boolean(nullable: false));
            DropColumn("dbo.AppUsers", "DateOfCreation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "DateOfCreation", c => c.DateTime());
            DropColumn("dbo.AppUsers", "IsArchived");
            DropColumn("dbo.AppUsers", "UpdatedBy");
            DropColumn("dbo.AppUsers", "UpdatedDate");
            DropColumn("dbo.AppUsers", "CreatedBy");
            DropColumn("dbo.AppUsers", "CreatedDate");
        }
    }
}
