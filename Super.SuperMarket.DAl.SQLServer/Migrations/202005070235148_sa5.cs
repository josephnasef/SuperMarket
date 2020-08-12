namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.AppUsers", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AppUsers", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
