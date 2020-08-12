namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "AppUser_Id", "dbo.AppUsers");
            DropIndex("dbo.Bills", new[] { "AppUser_Id" });
            RenameColumn(table: "dbo.Bills", name: "AppUser_Id", newName: "AppUserId");
            AlterColumn("dbo.Bills", "AppUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bills", "AppUserId");
            AddForeignKey("dbo.Bills", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Bills", new[] { "AppUserId" });
            AlterColumn("dbo.Bills", "AppUserId", c => c.Int());
            RenameColumn(table: "dbo.Bills", name: "AppUserId", newName: "AppUser_Id");
            CreateIndex("dbo.Bills", "AppUser_Id");
            AddForeignKey("dbo.Bills", "AppUser_Id", "dbo.AppUsers", "Id");
        }
    }
}
