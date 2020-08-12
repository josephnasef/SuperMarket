namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Bills", new[] { "AppUserId" });
            RenameColumn(table: "dbo.Bills", name: "AppUserId", newName: "AppUser_Id");
            AlterColumn("dbo.Bills", "AppUser_Id", c => c.Int());
            CreateIndex("dbo.Bills", "AppUser_Id");
            AddForeignKey("dbo.Bills", "AppUser_Id", "dbo.AppUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "AppUser_Id", "dbo.AppUsers");
            DropIndex("dbo.Bills", new[] { "AppUser_Id" });
            AlterColumn("dbo.Bills", "AppUser_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Bills", name: "AppUser_Id", newName: "AppUserId");
            CreateIndex("dbo.Bills", "AppUserId");
            AddForeignKey("dbo.Bills", "AppUserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
    }
}
