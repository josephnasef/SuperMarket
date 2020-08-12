namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppUsers", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.AppUsers", "DateOfCreation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppUsers", "DateOfCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AppUsers", "BirthDay", c => c.DateTime());
        }
    }
}
